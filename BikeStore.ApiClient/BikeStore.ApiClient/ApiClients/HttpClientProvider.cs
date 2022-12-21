using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.ApiClient.ApiClients
{
    public class HttpClientProvider
    {
        #region Private Properties

        public const string Base_Url = @"http://10.0.2.2:5252";

        #endregion

        #region Cosntructor
        public HttpClientProvider() { }
        #endregion

        public async Task<HttpClient> GetHttpClient()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(Base_Url);
            httpClient.Timeout = TimeSpan.FromMinutes(1); //Setting the API timeout 1 minute
            return httpClient;
        }
    }
}
