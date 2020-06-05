using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("lymb_prescription_state")]
    public class PrescriptionState
    {

        [Key]
        [Column("pharmacyId")]
        public string pharmacyId { get; set; }
        public int state { get; set; }
    }
}