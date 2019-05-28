using System;
using System.Threading.Tasks;
using Oplay.Helpers.Interfaces;

namespace Oplay.Helpers.Implementations
{
    public class SecureStorage : ISecureStorage
    {
        public async Task<string> GetAsync(string name)
        {
            return await Xamarin.Essentials.SecureStorage.GetAsync(name);
        }

        public async Task SetAsync(string name, string val)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync(name, val);
        }

        public void Remove(string name)
        {
            Xamarin.Essentials.SecureStorage.Remove(name);
        }
    }
}
