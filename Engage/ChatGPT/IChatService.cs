// [FILE] Engage.ChatGPT.IIIChatService.cs
using System.Threading.Tasks;
using Engage.ChatGPT.Models;

namespace Engage.ChatGPT
{
    public interface IChatService
    {
        Task<Message> SendMessageAsync(ApiRequestOptions requestOptions);
    }
}