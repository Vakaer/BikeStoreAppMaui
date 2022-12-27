﻿using BikeStore.Data.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.ApiClient.ApiClients.Interfaces
{
    public interface ICustomerApiClient
    {
        Task<List<CustomerCountFromEachCity>> GetCustomersCity();
        Task<List<OrdersCustomersOrderItemsLeftJoin>> GetOrderCustomerAndOrderItemsLeftJoin();
        Task<List<OrderCountByProduct>> GetTotalOrdersAgainstEachProduct();
        Task<List<ProductNamePriceForCategory>> GetProductAndCategoryRightJoin();
        Task<List<StaffSelfJoin>> GetStaffSelfJoin();
        Task<List<ProductAndOrderItems>> GetProductAndOrderItemsInnerJoin();
        Task<List<HighestDiscount>> GetHighestDiscount(int number);
        Task<List<decimal>> GetHighestDiscountDecimal(int number);
        Task<List<OrderForProductNamePriceID>> OrderForProductNamePriceID();
    }
}
