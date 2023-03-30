// [FILE] Engage.OpenAI.Models.ApiRequestOptions.cs
using System.Collections.Generic;

namespace Engage.OpenAI.Models
{
    public class ApiRequestOptions
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; }
    }
}
