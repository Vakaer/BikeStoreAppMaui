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
        [Get("​/api​/Customer​/GetTotalOrdersAgainstEachProduct")]
        Task<HttpResponseMessage> GetTotalOrdersAgainstEachProduct();
        [Get("/api/Customer/GetProductAndCategoryRightJoin")]
        Task<HttpResponseMessage> GetProductAndCategoryRightJoin();
        [Get("/api/Customer/GetStaffSelfJoin")]
        Task<HttpResponseMessage> GetStaffSelfJoin();
        [Get("/api/Customer/GetProductAndOrderItemsInnerJoin")]
        Task<HttpResponseMessage> GetProductAndOrderItemsInnerJoin();
        [Get("/api/Customer/GetHighestDiscount/{num}")]
        Task<HttpResponseMessage> GetHighestDiscount(int num);
        [Get("/api/Customer/OrderForProductNamePriceID")]
        Task<HttpResponseMessage> OrderForProductNamePriceID();
    }
}
