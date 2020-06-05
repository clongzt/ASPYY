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
    public class QueryScoreListController : ApiController
    {

        // POST api/values
        public string Post([FromBody]MobileParameter mobile)
        {
            using (var db = new BloggingContext())
            {
                var query = db.MemcardSales.AsNoTracking().Where(t => t.mobile == mobile.Mobile);
                var memcards = query.ToList();

                var msg = SuceessReturn(memcards);
                return msg; ;
            }
        }

        private string errorReturn()
        {
            var infos = new List<string>();
            var result = new
            {
                Code = -1,
                info = infos,
                msg = "获取失败"
            };
            return JsonConvert.SerializeObject(result); ;
        }

        private string SuceessReturn(IList<MemcardSale> scoreList)
        {
            var result = new
            {
                Code = 0,
                info = scoreList,
                msg = "成功"
            };
            return JsonConvert.SerializeObject(result); ;
        }


       
    }
}
