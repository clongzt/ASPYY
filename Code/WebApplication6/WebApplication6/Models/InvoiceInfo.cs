using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    /// <summary>
    /// 发票信息
    /// </summary>
      [Table("lymb_invoice")]
    public class InvoiceInfo
    {
        [Key]
        public string abcd { get; set; }
        public string orderid { get; set; }
           public string prescriptionid { get; set; }
           
        public string type { get; set; }

        public string guest { get; set; }

        public string title { get; set; }

        public string taxpayerid { get; set; }

        public Nullable<System.DateTime> createtime { get; set; }
    }
}