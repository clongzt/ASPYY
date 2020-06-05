using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class CancellationOrderResultIfno
    {
        public String abcd { get; set; }

        public string orderid { get; set; }
        public bool accepted { get; set; }



        public string message { get; set; }

        public int status { get; set; }
    }
}