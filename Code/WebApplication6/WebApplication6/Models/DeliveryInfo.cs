using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    /// <summary>
    /// 收获信息
    /// </summary>
    [Table("lymb_delivery")]
    public class DeliveryInfo
    {
          [Key]
        public string abcd { get; set; }
        public string orderid { get; set; }
        public string prescriptionid { get; set; }

        public string province { get; set; }
        public string city { get; set; }

        public string district { get; set; }

        public string address { get; set; }

        public string contact { get; set; }

        public string phone { get; set; }

        public Nullable<System.DateTime> createtime { get; set; }
    }
}