using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class PrescriptionInfoResultInfo
    {
        
        public String abcd { get; set; }
        public string prescriptionid { get; set; }

        public string pharmacyId { get; set; }

        public long time { get; set; }


        public int state
        {
            get;
            set;
        }

        private bool accept=true;
        public bool accepted
        {
            get
            {
                return accept;
            }
            set
            {
                accept = value;
            }
        }
        public string message { get; set; }

        public string opid { get; set; }

        public string opname { get; set; }

    }
}