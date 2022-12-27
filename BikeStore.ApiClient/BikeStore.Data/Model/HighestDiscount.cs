using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Model
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class HighestDiscount
    {
        [JsonProperty(PropertyName = "Discount")]
        public List<decimal> Discount { get; set; }
    }
}
