// [FILE] Engage.OpenAI.IIIChatService.cs
using System.Threading.Tasks;
using Engage.OpenAI.Models;

namespace Engage.OpenAI
{
    public interface IChatService
    {
        Task<Message> SendMessageAsync(ApiRequestOptions requestOptions);
    }
}