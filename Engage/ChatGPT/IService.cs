// [FILE] Engage.ChatGPT.IService.cs
using System.Threading.Tasks;
using Engage.ChatGPT.Models;

namespace Engage.ChatGPT
{
    public interface IService
    {
        Task<Message> SendMessageAsync(ApiRequestOptions requestOptions);
    }
}