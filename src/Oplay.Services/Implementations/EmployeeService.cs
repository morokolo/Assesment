using System;
using System.Threading.Tasks;
using Oplay.Models.Response;
using Oplay.Services.Constants;
using Oplay.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Oplay.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
       
        readonly HttpClient _client;
        readonly string _url;

        public List<EmployeeResponse> Items { get; private set; }

        public EmployeeService()
        {
            _client = new HttpClient();
            _url = ServiceURLs.BaseURL;
        }


       public async Task<List<EmployeeResponse>> GetEmployeesAsync()
        {
            Items = new List<EmployeeResponse>();

            var uri = new Uri(string.Format($"{_url}{ServiceURLs.UserEmployeeEndpoint}", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<EmployeeResponse>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
