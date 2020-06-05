using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class ScoreOnlineController : ApiController
    {

        // POST api/values
        public string Post([FromBody]ScoreOnline scoreOnline)
        {
            using (var db = new BloggingContext())
            {
                try
                {
                    db.ScoreOnlines.Add(scoreOnline);
                    db.SaveChanges();
                    return SuceessReturn(); 
                }
                catch (Exception e)
                {
                    return errorReturn();
                }
               
               
            }
        }

        private string errorReturn()
        {
            var result = new
            {
                Code = -1,
                msg = "通讯异常"
            };
            return JsonConvert.SerializeObject(result);
        }

        private string SuceessReturn()
        {
            var result = new
            {
                Code = 0,
                msg = "请求成功"
            };
            return JsonConvert.SerializeObject(result); 
        }


       
    }
}
