// [FILE] Engage.OpenAI.Models.Message.cs
using System.Text.Json.Serialization;

namespace Engage.OpenAI.Models
{
    public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }
}
