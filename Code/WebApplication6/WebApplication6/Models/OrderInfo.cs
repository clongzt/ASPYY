using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
       [Table("lymb_order")]
    public class OrderInfo
    {
            [Key]
        public String abcd { get; set; }

        public string orderid { get; set; }
        public string prescriptionid { get; set; }


        public decimal fee { get; set; }

        public decimal ybfee { get; set; }

        public decimal ybpay { get; set; }
        public decimal thirdpay { get; set; }

        public string type { get; set; }

      

        public string paymentstandard { get; set; }

        public string pharmacyId { get; set; }

        public int status { get; set; }

        public string transType { get; set; }

        public string source { get;   set; }

        public string opid { get; set; }

        public string note { get; set; }

        public Nullable<System.DateTime> cancletime { get; set; }

        public Nullable<System.DateTime> createtime { get; set; }

        public Nullable<System.DateTime> modifytime { get; set; }       

      
    }
}