using System;
using System.Threading.Tasks;

namespace Oplay.Services.Interfaces
{
    public interface IStorageHelper
    {
        Task SetAuthenticationTokenAsync(string jwtToken);

        Task<string> GetAuthenticationTokenAsync();

        Task SetAuthenticationReferenceAsync(string authToken);

        Task<string> GetAuthenticationReferenceAsync();

        Task SetUsernameAsync(string username);

        Task<string> GetUsernameAsync();

        Task SetUserPasswordAsync(string userPassword);

        Task<string> GetUserPasswordAsync();

        void RemoveAuthenticationTokenAsync();

        Task SetUserNumberAsync(string username);

        Task<string> GetUserNumberAsync();
    }
}
