using Pandemic.Common.Models;
using System.Threading.Tasks;

namespace Pandemic.Common.Services
{
    public interface IApiService
    {
        Task<Response> PutAsync<T>(string urlBase, string servicePrefix, string controller, T model, string tokenType, string accessToken);
        Task<Response> ChangePasswordAsync(string urlBase, string servicePrefix, string controller, ChangePasswordRequest changePasswordRequest, string tokenType, string accessToken);
        Task<bool> CheckConnectionAsync(string url);
        Task<Response> RegisterUserAsync(string urlBase, string servicePrefix, string controller, UserRequest userRequest);
        Task<Response> GetUserByEmail(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, EmailRequest request);
        Task<Response> GetTokenAsync(
        string urlBase,
        string servicePrefix,
        string controller,
        TokenRequest request);
        Task<Response> GetUserByEmailAsync(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken,
        string email);

        Task<Response> RecoverPasswordAsync(
        string urlBase,
        string servicePrefix,
        string controller,
        EmailRequest emailRequest);


    }
}
