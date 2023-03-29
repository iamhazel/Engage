// [FILE] Engage.ChatGPT.ApiClient.cs
using Engage.ChatGPT.Models;
using Engage.Converters;
using Engage.Helpers;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Engage.ChatGPT
{
    // This class is responsible for sending messages to the OpenAI API
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly ILogger<ApiClient> _logger;

        // Constructor that takes an HttpClient, IConfiguration, and ILogger
        public ApiClient(HttpClient httpClient, ILocalSettingsService localSettingsService, ILogger<ApiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Add this line
                PropertyNameCaseInsensitive = true
            };
            _jsonSerializerOptions.Converters.Add(new UnixTimestampConverter()); // Add this line

            // Get the OpenAI API key from the configuration
            string apiKey = localSettingsService.GetSetting("OpenAIKey");

            // Throw an exception if the API key is not found
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new InvalidOperationException("OpenAI API Key not found in configuration.");
            }

            // Set the Authorization header on the HttpClient to include the API key
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            Debug.WriteLine(apiKey);
        }

        // Method for sending a message to the OpenAI API
        public async Task<Response> SendMessageAsync(ApiRequestOptions requestOptions)
        {
            // Serialize the request body to JSON
            string jsonString = JsonSerializer.Serialize(requestOptions, _jsonSerializerOptions);
            Debug.WriteLine($"Request JSON: {jsonString}");

            // Create an HttpContent object with the serialized JSON as its content
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            HttpResponseMessage response;

            try
            {
                // Send the POST request to the OpenAI API using the HttpClient
                string url = "chat/completions";
                Debug.WriteLine($"Request URL: {_httpClient.BaseAddress}{url}"); // Log the request URL

                // Send the POST request to the OpenAI API using the HttpClient
                response = await _httpClient.PostAsync("chat/completions", content).ConfigureAwait(false);
                _logger.LogInformation("Response received from API");
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that occur during the request
                _logger.LogError(ex, "Error sending message to OpenAI API");
                throw;
            }

            if (!response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine($"Received a non-success status code: {response.StatusCode}. Response content: {responseContent}");
                _logger.LogError("Received a non-success status code: {StatusCode}. Response content: {ResponseContent}", response.StatusCode, responseContent);
                return null;
            }

            try
            {
                // Read the response content as a string and deserialize it to a Response object
                jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Debug.Write(jsonString);
                return JsonSerializer.Deserialize<Response>(jsonString, _jsonSerializerOptions);
            }
            catch (JsonException ex)
            {
                Debug.WriteLine(ex, "Error deserializing JSON response");
                throw;
            }
        }
    }
}