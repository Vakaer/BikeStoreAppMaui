using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Model
{
    public class OrderForProductNamePriceID
    {
        public string ProductName { get; set; }
        public string ProductNameChar { get; set; }
        public decimal ListPrice { get; set; }
        public int ProductId { get; set; }
        public int OrderCount { get; set; }
    }
}
