// [FILE] Engage.ChatGPT.Models.ApiRequestOptions.cs
using System.Collections.Generic;

namespace Engage.ChatGPT.Models
{
    public class ApiRequestOptions
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; }
    }
}
