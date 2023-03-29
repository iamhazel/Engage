// [FILE] Engage.ChatGPT.IApiClient.cs
using System.Threading.Tasks;
using Engage.ChatGPT.Models;

namespace Engage.ChatGPT
{
    public interface IApiClient
    {
        Task<Response> SendMessageAsync(ApiRequestOptions requestOptions);
    }
}