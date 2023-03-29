// [FILE] Engage.ChatGPT.Models.Message.cs
using System.Text.Json.Serialization;

namespace Engage.ChatGPT.Models
{
    public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
}
