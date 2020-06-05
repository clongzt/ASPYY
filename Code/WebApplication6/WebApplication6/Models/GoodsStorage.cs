using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("v_jksc_store")]
    public class GoodsStorage
    {
        [Key,Column(Order=1)]
        public string uid { get; set; }
        [Key, Column(Order = 2)]
        public string goodsno { get; set; }
        public string spec { get; set; }
        public string state { get; set; }
        public Nullable<decimal> cqty { get; set; }
    }
}