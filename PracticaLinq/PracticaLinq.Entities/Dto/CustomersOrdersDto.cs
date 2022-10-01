using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLinq.Entities.Dto
{
    public class CustomersOrdersDto
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }

        public int OrderID { get; set; }

        public string Region { get; set; }

        public DateTime? OrderDate { get; set; }

        public int QuantityOrders { get; set; }

    }
}
