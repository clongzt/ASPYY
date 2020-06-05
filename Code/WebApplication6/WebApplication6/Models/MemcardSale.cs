using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("v_jksc_memcard_sale")]
    public class MemcardSale
    {
        [Key]
        public string num { get; set; }
        public string mname { get; set; }
        public string spec { get; set; }
        public System.DateTime vdate { get; set; }
        public decimal summoney { get; set; }
        public string state { get; set; }
        public decimal integral { get; set; }
        public string mobile { get; set; }
    }
}