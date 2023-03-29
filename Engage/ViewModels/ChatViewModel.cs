// [FILE] Engage.ViewModels.ChatViewModel.cs
using Engage.ChatGPT;
using Engage.ChatGPT.Models;
using Engage.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Engage.ViewModels
{
    public class ChatViewModel : BaseViewModel
    {
        private readonly IApiClient _apiClient;
        private readonly ILogger<ChatViewModel> _logger;

        private string _message;
        private string _inputMessageSource = "user";
        private bool _isSendingMessage;

        public RelayCommand<object> SendMessageCommand { get; }
        public RelayCommand<object> ToggleSendingCommand { get; }
        public IService ChatService { get; set; }

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public string InputMessageSource
        {
            get => _inputMessageSource;
            set => SetProperty(ref _inputMessageSource, value);
        }

        public bool IsSendingMessage
        {
            get => _isSendingMessage;
            set => SetProperty(ref _isSendingMessage, value);
        }

        private int _selectedModelIndex = 1;
        public int SelectedModelIndex
        {
            get => _selectedModelIndex;
            set => SetProperty(ref _selectedModelIndex, value);
        }
        public string SelectedModel => SelectedModelIndex == 0 ? "gpt-4" : "gpt-3.5-turbo";

        private string _newMessageText;
        public string NewMessageText
        {
            get => _newMessageText;
            set => SetProperty(ref _newMessageText, value);
        }

        private ObservableCollection<MessageViewModel> _messages;
        public ObservableCollection<MessageViewModel> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        public ChatViewModel(IApiClient apiClient, ILogger<ChatViewModel> logger)
        {
            _apiClient = apiClient;
            _logger = logger;

            SendMessageCommand = new RelayCommand<object>(async param => await SendMessageAsync(), param => !IsSendingMessage);

            Messages = new ObservableCollection<MessageViewModel>();
        }

        private async Task SendMessageAsync()
        {
            ChatMessageType chatMessageType = InputMessageSource == "assistant" ? ChatMessageType.Received : ChatMessageType.Sent;

            var userMessage = new Message { Content = NewMessageText, Role = InputMessageSource == "assistant" ? "assistant" : "user" };
            var userMessageViewModel = new MessageViewModel(userMessage, chatMessageType);
            Messages.Add(userMessageViewModel);

            NewMessageText = string.Empty;

            // AI chat message
            if (InputMessageSource != "assistant")
            {
                var initialSystemMessage = new Message { Role = "system", Content = "You are a helpful assistant." };
                var messages = new List<Message> { initialSystemMessage };

                // Add previous messages to the list
                foreach (var messageViewModel in Messages)
                {
                    messages.Add(new Message { Content = messageViewModel.Content, Role = messageViewModel.Role });
                }

                var requestOptions = new ApiRequestOptions { Model = SelectedModel, Messages = messages };
                var response = await _apiClient.SendMessageAsync(requestOptions);
                var assistantMessage = new MessageViewModel(new Message { Content = response.Choices[0].Message.Content, Role = "assistant" }, ChatMessageType.Received);
                Messages.Add(assistantMessage);
            }
            NewMessageText = string.Empty;
        }

    }
}
