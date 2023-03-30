// [FILE] Engage.OpenAI.ChatService.cs
using Engage.OpenAI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Engage.OpenAI
{
    public class ChatService : IChatService
    {
        private readonly IApiClient _apiClient;
        
        public ChatService(IApiClient apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
        }

        public async Task<Message> SendMessageAsync(ApiRequestOptions requestOptions)
        {
            try
            {
                var chatGPTResponse = await _apiClient.SendMessageAsync(requestOptions);

                if (chatGPTResponse is null || chatGPTResponse.Choices is null || chatGPTResponse.Choices.Count == 0)
                {
                    Debug.WriteLine("No response received.");
                    return null;
                }

                var responseMessage = new Message
                {
                    Role = chatGPTResponse.Choices[0].Message.Role,
                    Content = chatGPTResponse.Choices[0].Message.Content
                };

                return responseMessage;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error sending message to chat GPT API: {ex}");
                throw;
            }
        }
    }
}
