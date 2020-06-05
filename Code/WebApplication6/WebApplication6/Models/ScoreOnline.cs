using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("d_jksc_xsjf")]
    public class ScoreOnline
    {
        [Key,Column(Order=1)]
        public string mobile { get; set; }
       
        public string tradesId { get; set; }
        public string goods_num { get; set; }
        public decimal sumScore { get; set; }
        public decimal on_costScore { get; set; }
        public decimal off_costScore { get; set; }
        [Key, Column(Order = 2)]
        public string create_time { get; set; }
        public string notes { get; set; }
        public Nullable<decimal> on_integral { get; set; }
        public Nullable<decimal> off_integral { get; set; }
    }
}