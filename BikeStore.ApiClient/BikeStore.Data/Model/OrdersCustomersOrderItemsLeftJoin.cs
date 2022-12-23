using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Model
{
    public class OrdersCustomersOrderItemsLeftJoin
    {
        public string FullName { get; set; }
        public string FullNameChar { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }
    }
}
