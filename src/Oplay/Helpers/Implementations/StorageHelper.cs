using System;
using System.Threading.Tasks;
using Oplay.Constants;
using Oplay.Helpers.Interfaces;
using Oplay.Services.Interfaces;

namespace Oplay.Helpers.Implementations
{
    public class StorageHelper : IStorageHelper
    {
        private readonly ISecureStorage _secureStorage;

        public StorageHelper(ISecureStorage secureStorage)
        {
            _secureStorage = secureStorage;
        }

        private void ValidateValue(string key, string val)
        {
            if (string.IsNullOrWhiteSpace(val))
                throw new ArgumentException(string.Format("{0} cannot be null or empty", key));
        }

        public async Task SetAuthenticationReferenceAsync(string authReference)
        {
            ValidateValue(StorageKeys.AUTH_REFERENCE, authReference);

            await _secureStorage.SetAsync(StorageKeys.AUTH_REFERENCE, authReference);
        }

        public async Task<string> GetAuthenticationReferenceAsync()
        {
            return await _secureStorage.GetAsync(StorageKeys.AUTH_REFERENCE);
        }


        public async Task SetAuthenticationTokenAsync(string jwtToken)
        {
            ValidateValue(StorageKeys.AUTH_JWT_TOKEN, jwtToken);

            await _secureStorage.SetAsync(StorageKeys.AUTH_JWT_TOKEN, jwtToken);
        }

        public async Task<string> GetAuthenticationTokenAsync()
        {
            return await _secureStorage.GetAsync(StorageKeys.AUTH_JWT_TOKEN);
        }

        public async Task SetUsernameAsync(string username)
        {
            ValidateValue(StorageKeys.AUTH_USERNAME, username);

            await _secureStorage.SetAsync(StorageKeys.AUTH_USERNAME, username);
        }

        public async Task<string> GetUsernameAsync()
        {
            return await _secureStorage.GetAsync(StorageKeys.AUTH_USERNAME);
        }

        public async Task SetUserPasswordAsync(string password)
        {
            ValidateValue(StorageKeys.AUTH_USER_PASSWORD, password);

            await _secureStorage.SetAsync(StorageKeys.AUTH_USER_PASSWORD, password);
        }

        public async Task<string> GetUserPasswordAsync()
        {
            return await _secureStorage.GetAsync(StorageKeys.AUTH_USER_PASSWORD);
        }

        public void RemoveAuthenticationTokenAsync()
        {
            _secureStorage.Remove(StorageKeys.AUTH_JWT_TOKEN);
            _secureStorage.Remove(StorageKeys.AUTH_TOKEN);
            _secureStorage.Remove(StorageKeys.AUTH_USER_PASSWORD);
            _secureStorage.Remove(StorageKeys.AUTH_USERNAME);
        }


        public async Task SetUserNumberAsync(string number)
        {
            ValidateValue(StorageKeys.AUTH_USER_NUMBER, number);

            await _secureStorage.SetAsync(StorageKeys.AUTH_USER_NUMBER, number);
        }

        public async Task<string> GetUserNumberAsync()
        {
            return await _secureStorage.GetAsync(StorageKeys.AUTH_USER_NUMBER);
        }
    }
}
