using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class OrderInfoDto
    {
        public String abcd { get; set; }
        public string prescriptionid { get; set; }

        public string orderid { get; set; }

        public decimal fee { get; set; }

        public decimal ybfee { get; set; }

        public decimal ybpay { get; set; }
        public decimal thirdpay { get; set; }

        public string type { get; set; }

        public DeliveryInfo delivery { get; set; }

        public InvoiceInfo invoice { get; set; }

        public string paymentstandard { get; set; }

        public string pharmacyId { get; set; }
    }
}