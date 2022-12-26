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

        
        private HttpClientProvider _httpClientProvider;
        

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

        public async Task<List<OrderCountByProduct>> GetTotalOrdersAgainstEachProduct()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetTotalOrdersAgainstEachProduct();
                return await HttpResponseHelper.GetObjectFor<List<OrderCountByProduct>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<ProductNamePriceForCategory>> GetProductAndCategoryRightJoin()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetProductAndCategoryRightJoin();
                return await HttpResponseHelper.GetObjectFor<List<ProductNamePriceForCategory>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<StaffSelfJoin>> GetStaffSelfJoin()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetStaffSelfJoin();
                return await HttpResponseHelper.GetObjectFor<List<StaffSelfJoin>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<ProductAndOrderItems>> GetProductAndOrderItemsInnerJoin()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetProductAndOrderItemsInnerJoin();
                return await HttpResponseHelper.GetObjectFor<List<ProductAndOrderItems>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public async Task<HighestDiscount> GetHighestDiscount(int number)
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetHighestDiscount(number);
                return await HttpResponseHelper.GetObjectFor<HighestDiscount>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<List<OrderForProductNamePriceID>> OrderForProductNamePriceID()
        {
            try
            {
                var response = await RestService
                    .For<ICustomerApi>(await GetHttpClient())
                    .GetProductAndOrderItemsInnerJoin();
                return await HttpResponseHelper.GetObjectFor<List<OrderForProductNamePriceID>>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
