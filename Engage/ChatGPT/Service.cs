// [FILE] Engage.ChatGPT.Service.cs
using Engage.ChatGPT.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Engage.ChatGPT
{
    public class Service : IService
    {
        private readonly IApiClient _apiClient;

        public Service(IApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public async Task<Message> SendMessageAsync(ApiRequestOptions requestOptions)
        {
            try
            {
                var chatGPTResponse = await _apiClient.SendMessageAsync(requestOptions);

                if (chatGPTResponse.Choices != null && chatGPTResponse.Choices.Count > 0)
                {
                    var responseMessage = new Message
                    {
                        Role = chatGPTResponse.Choices[0].Message.Role,
                        Content = chatGPTResponse.Choices[0].Message.Content
                    };

                    return responseMessage;
                }
                else
                {
                    Debug.WriteLine("No response received.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error sending message to chat GPT API: {ex}");
                throw;
            }
        }
    }
}