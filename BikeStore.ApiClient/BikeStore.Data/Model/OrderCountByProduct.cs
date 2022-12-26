using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Model
{
    public class OrderCountByProduct
    {
        public int ProductId { get; set; }
        public int OrdersCount { get; set; }
        public string ProductName { get; set; }
        public string ProductNameChar { get; set; }
    }
}
