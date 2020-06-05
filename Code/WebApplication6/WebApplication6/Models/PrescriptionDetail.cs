using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
     [Table("lymb_prescription_detail")]
    public class PrescriptionDetail
    {
        [Key, Column(Order = 0)]
        public string abcd { get; set; }

          
        public string prescriptionid { get; set; }

         [Key, Column(Order = 1)]
        public string aae005 { get; set; }
        public string ake001 { get; set; }
        public string ake003 { get; set; }
        public string display { get; set; }
        public string gyzz { get; set; }
        public string form { get; set; }
        public string spec { get; set; }
        public decimal num { get; set; }
        public string dosage { get; set; }

        public string usage { get; set; }

        public string note { get; set; }

        public string createtime { get; set; }
      
    }
}