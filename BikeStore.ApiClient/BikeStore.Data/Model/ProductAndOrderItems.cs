using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Model
{
    public class ProductAndOrderItems
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductNameChar { get; set; }
        public int OrderId { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
