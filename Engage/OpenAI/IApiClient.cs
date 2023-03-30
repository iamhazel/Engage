// [FILE] Engage.OpenAI.IApiClient.cs
using System.Threading.Tasks;
using Engage.OpenAI.Models;

namespace Engage.OpenAI
{
    public interface IApiClient
    {
        Task<Response> SendMessageAsync(ApiRequestOptions requestOptions);
    }
}