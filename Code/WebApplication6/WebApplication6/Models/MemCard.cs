using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    [Table("u_memcard_reg")]
    public class MemCard
    {
        [Column("memcardno")] 
        public string Card_no { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }


        [Column("idcard")]
        public string certif_no { get; set; }

        [Column("cardstatus")] 
        public byte  state { get; set; }
        public decimal integral { get; set; }

        [Column("cardholder")]
        public string Name { get; set; }
        [Column("cardaddress")]
        public string address { get; set; }
        public string sex { get; set; }

        public byte cardtype { get; set; }
        public byte cardlevel { get; set; }
        public string lever
        {
            get
            {
                if (cardtype == 2)
                {
                    return "1";
                }
                return "0";
            }
        }

        public string email
        {
            get { return ""; }
        }

         [Column("handset")]
        [Key]
        public string mobile { get; set; }
        
    }
}
