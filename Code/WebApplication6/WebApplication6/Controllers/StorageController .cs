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
    public class StorageController : ApiController
    {

        // POST api/values
        public string Post([FromBody] StorageParameter storageParameter)
        {
            using (var db = new BloggingContext())
            {
                try
                {


                    var goodsNoList = storageParameter.GoodsNo.Split(',');
                    var uIdList = storageParameter.UID.Split(',');
                    var query = from b in db.GoodsStorages
                        where goodsNoList.Contains(b.goodsno) && uIdList.Contains(b.uid)
                        select b;
                    var memcards = query.ToList();

                    var msg = SuceessReturn(memcards);
                    return msg;
                }
                catch (Exception e)
                {
                    return errorReturn();
                }
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

        private string SuceessReturn(IList<GoodsStorage> results)
        {
           
            var result = new
            {
                Code = 0,
                info = results,
                msg = "成功"
            };
            return JsonConvert.SerializeObject(result); ;
        }


       
    }
}
