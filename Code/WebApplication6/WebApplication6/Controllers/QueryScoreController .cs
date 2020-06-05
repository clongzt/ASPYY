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
    public class QueryScoreController : ApiController
    {

        // POST api/values
        public string Post([FromBody]MobileParameter mobile)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.MemCards
                            where b.mobile == mobile.Mobile
                    select new {score=b.integral};
                var memcards = query.ToList();
                var msg = "";
                if (memcards.Count < 1)
                {
                    msg = errorReturn();
                }
                msg = SuceessReturn(memcards[0].score.ToString());
                return msg; ;
            }
        }

        private string errorReturn()
        {
            var infos = new List<string>();
            var result = new 
            {
                Code = -1,
                info=infos,
                msg = "获取失败"
            };
            return JsonConvert.SerializeObject(result); ;
        }

        private string SuceessReturn(string score)
        {

            var scoreObject = new
            {
                gold_score = score
            };
            var scoreList = new List<object>();
            scoreList.Add(scoreObject);
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
