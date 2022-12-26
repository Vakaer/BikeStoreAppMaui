using BikeStore.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BikeStore.ApiClient.Helpers
{
    public class HttpResponseHelper
    {
        private static HttpResponseHelper _httpResponseHelper;
        public HttpResponseHelper()
        {
            _httpResponseHelper = this;
        }

        public static async Task<T> GetObjectFor<T> (HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var serialized = await response.Content.ReadAsStringAsync();
                JArray results = (JArray)serialized;
                var jsonString = JsonConvert.SerializeObject(results);
                //var resultData = JsonConvert.DeserializeObject<Root>(jsonString);
                return JsonConvert.DeserializeObject<T>(serialized);
            }
            return default(T);
        }
        public static async Task<string> GetAsString(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return null;
        }
    }
}
