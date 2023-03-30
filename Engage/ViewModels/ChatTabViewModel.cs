// [FILE] Engage.ViewModels.ChatTabViewModel.cs
using Engage.Models;
using Engage.OpenAI;
using Engage.OpenAI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Engage.ViewModels
{
    public class ChatTabViewModel : BaseViewModel
    {
        // Interfaces
        private readonly IChatService _chatService;
        public ICommand SendMessageCommand { get; set; }
        public IChatService ChatService { get; set; }
        // Models
        public CustomRelayCommand ToggleMessageSendingCommand { get; }
        private ObservableCollection<MessageViewModel> _messages;
        public ObservableCollection<MessageViewModel> Messages
        {
            get => _messages;
            set => SetProperty(ref _messages, value);
        }

        // Properties
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private int _selectedRoleIndex = 0;
        public int SelectedRoleIndex
        {
            get => _selectedRoleIndex;
            set => SetProperty(ref _selectedRoleIndex, value);
        }
        public string SelectedRole => SelectedRoleIndex == 0 ? "user" : "assistant";

        private bool _isSendingMessage;
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

        private string _tabName;
        public string TabName
        {
            get => _tabName;
            set
            {
                SetProperty(ref _tabName, value);
                OnPropertyChanged(nameof(TabName));
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        // Methods
        public ChatTabViewModel(IChatService service, string tabName)
        {
            _chatService = service;
            SendMessageCommand = new CustomRelayCommand(async () => await SendMessageAsync(), () => !IsSendingMessage);
            Messages = new ObservableCollection<MessageViewModel>();
            TabName = tabName;
        }

        public void ClearMessages()
        {
            Messages.Clear();
        }

        public event EventHandler MessageSent;

        private async Task SendMessageAsync()
        {
            if (string.IsNullOrWhiteSpace(NewMessageText))
            {
                return;
            }

            ChatMessageType chatMessageType = SelectedRole == "assistant" ? ChatMessageType.Received : ChatMessageType.Sent;

            var userMessage = new Message { Content = NewMessageText, Role = SelectedRole };
            var userMessageViewModel = new MessageViewModel(userMessage, chatMessageType);
            Messages.Add(userMessageViewModel);

            NewMessageText = string.Empty;

            if (SelectedRole != "assistant")
            {
                var messages = new List<Message>
                {
                    new Message { Content = "You are a helpful assistant.", Role = "system" }
                };

                // Add previous messages to the list
                foreach (var messageViewModel in Messages)
                {
                    messages.Add(new Message { Content = messageViewModel.Content, Role = messageViewModel.Role });
                }

                var requestOptions = new ApiRequestOptions { Model = SelectedModel, Messages = messages };
                var response = await _chatService.SendMessageAsync(requestOptions);

                if (response != null)
                {
                    var assistantMessageViewModel = new MessageViewModel(new Message { Content = response.Content, Role = "assistant" }, ChatMessageType.Received);
                    Messages.Add(assistantMessageViewModel);
                }
            }
            MessageSent?.Invoke(this, EventArgs.Empty);
        }
    }

}
