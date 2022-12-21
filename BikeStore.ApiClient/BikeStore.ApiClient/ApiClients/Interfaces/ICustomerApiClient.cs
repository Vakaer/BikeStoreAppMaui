using BikeStore.Data.Model;
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
    }
}
