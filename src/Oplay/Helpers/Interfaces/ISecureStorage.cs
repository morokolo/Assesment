using System;
using System.Threading.Tasks;

namespace Oplay.Helpers.Interfaces
{
    public interface ISecureStorage
    {
        Task<String> GetAsync(string name);

        Task SetAsync(string name, string val);

        void Remove(string name);
    }
}
