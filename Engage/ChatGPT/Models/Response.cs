// [FILE] Engage.ChatGPT.Models.Response.cs
using Engage.Converters;
using Engage.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Engage.ChatGPT.Models
{
    public class Response
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created")]
        [System.Text.Json.Serialization.JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime Created { get; set; }

        public List<Choice> Choices { get; set; }
        public string Model { get; set; }
        public string Object { get; set; }
        public ResponseUsage Usage { get; set; }
       

        public class Choice
        {
            public string FinishReason { get; set; }
            public int Index { get; set; }
            public Message Message { get; set; }
        }

        public class ResponseUsage
        {
            public int CompletionTokens { get; set; }
            public int PromptTokens { get; set; }
            public int TotalTokens { get; set; }
        }

        public static Response FromJson(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<Response>(json);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error deserializing response from JSON: {ex}");
                throw;
            }
        }
    }
}
