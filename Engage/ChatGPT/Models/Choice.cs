﻿// [FILE] Engage.ChatGPT.Models.Usage.cs
namespace Engage.ChatGPT.Models
{
    public class Choice
    {
        public string FinishReason { get; set; }
        public int Index { get; set; }
        public string Text { get; set; }
        // public string Role { get; set; }
    }
}