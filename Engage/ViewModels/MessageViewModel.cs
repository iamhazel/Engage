// [FILE] Engage.ViewModels.MessageViewModel.cs
using Engage.OpenAI.Models;
using Engage.Helpers;

namespace Engage.ViewModels
{
    public enum ChatMessageType
    {
        Sent,
        Received
    }

    public class MessageViewModel
    {
        public string Role { get; }
        public string Content { get; }
        public ChatMessageType ChatMessageType { get; }

        public MessageViewModel(Message message, ChatMessageType chatMessageType)
        {
            Role = message.Role;
            Content = message.Content;
            ChatMessageType = chatMessageType;
        }
    }
}
