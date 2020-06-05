using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("lymb_prescription")]
    public class PrescriptionInfo
    {
        [Key]
        [Column("abcd")]
        public string abcd {get; set; }
        public string prescriptionid { get; set; }

        public string pharmacyId { get; set; }

        public string orgid { get; set; }

        public string hospital { get; set; }

        public string doctor { get; set; }
        public string doctorid { get; set; }

        public string checkdoctor { get; set; }

        public string checkdoctorid { get; set; }

        public string diseaseid { get; set; }


        public string outpatientid { get; set; }
        public string day { get; set; }

        public string expiry { get; set; }

        public int daysinventory { get; set; }

        public string name { get; set; }

        public string idtype { get; set; }
        public string publicid { get; set; }

        public string createtime { get; set; }

        public string opid { get; set; }

        public string opname { get; set; }

         public string accepted { get; set; }

        public string modifytime { get; set; }

        [NotMapped]
        public virtual List<PrescriptionDetail> list { get; set; }

    }
}