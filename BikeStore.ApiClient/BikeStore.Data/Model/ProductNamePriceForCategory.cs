using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Model
{
    public class ProductNamePriceForCategory
    {
        public string CategoryName { get; set; }
        public string CategoryNameChar { get; set; }
        public string ProductName { get; set; }
        public int ModelYear { get; set; }
        public decimal ListPrice { get; set; }
    }
}
