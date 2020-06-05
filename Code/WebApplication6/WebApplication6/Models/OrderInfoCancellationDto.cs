using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class OrderInfoCancellationDto
    {
        public String abcd { get; set; }

        public string orderid { get; set; }
        public string transType { get; set; }



        public string source { get; set; }

        public string opid { get; set; }

        public String note { get; set; }
        public string pharmacyId { get; set; }

       
    }
}