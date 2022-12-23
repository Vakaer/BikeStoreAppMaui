using BikeStore.ApiClient.ApiClients.Interfaces;
using BikeStore.ApiClient.Helpers;
using BikeStore.Data.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BikeStore.ApiClient.ApiClients
{
    public class CustomerApiClient : ICustomerApiClient
    {
        #region private properties

        private readonly HttpClient _httpClient;
        private HttpClientProvider _httpClientProvider;
        private readonly ICustomerApi _customerApi;
        JsonSerializerOptions _serializerOptions;

        #endregion

        #region Constructor instantiating the Base URL
        public CustomerApiClient(HttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
            
        }
        protected async Task<HttpClient> GetHttpClient()
        {
            return await _httpClientProvider.GetHttpClient();
        }

        #endregion


        public async Task<List<CustomerCountFromEachCity>> GetCustomersCity()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetCustomersCity();
                return await HttpResponseHelper.GetObjectFor<List<CustomerCountFromEachCity>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public async Task<List<OrdersCustomersOrderItemsLeftJoin>> GetOrderCustomerAndOrderItemsLeftJoin()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetOrderCustomerAndOrderItemsLeftJoin();
                return await HttpResponseHelper.GetObjectFor<List<OrdersCustomersOrderItemsLeftJoin>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
