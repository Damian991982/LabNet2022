using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaLinq.Entities.Dto
{
    public class CustomerDto
    {
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string CompanyNameUppercase=>CompanyName.ToUpper();
        public string CompanyNameLowercase=>CompanyName.ToLower();
    }
}
