using BikeStore.Data.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BikeStore.ApiClient.ApiClients.Interfaces
{
    public interface ICustomerApi
    {
        [Get("/api/Customer/GetcustomersCity")]
        Task<HttpResponseMessage> GetCustomersCity();
        [Get("/api/Customer/GetOrderCustomerAndOrderItemsLeftJoin")]
        Task<HttpResponseMessage> GetOrderCustomerAndOrderItemsLeftJoin();
    }
}
