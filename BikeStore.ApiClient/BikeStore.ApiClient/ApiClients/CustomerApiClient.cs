using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.Data.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.ApiClient.ApiClients
{
    public class CustomerApiClient : ICustomerApiClient
    {
        #region private properties

        private readonly HttpClient _httpClient;
        private readonly ICustomerApi _customerApi;

        #endregion

        #region Constructor instantiating the Base URL
        public CustomerApiClient()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(HttpClientProvider.Base_Url),
                Timeout = TimeSpan.FromMinutes(1)
            };
            _customerApi = RestService.For<ICustomerApi>(_httpClient);
            
        }

        #endregion
        public async Task<ApiResponse<CustomerCountFromEachCity>> GetCustomersCity()
        {
            return await _customerApi.GetCustomersCity();
        }
    }
}
