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
    public class MemCardsController : ApiController
    {
        // GET api/values
        public string Get()
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.Users
                    orderby b.Name
                    select b;
                var result = new Results
                {
                    Code = 0 ,
                    info = query.ToList() ,
                    msg = "success"

                };
                return JsonConvert.SerializeObject(result); ;
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value"+id;
        }

        
        public string Get(string name)
        {
            return name + "kaka";
        }

        public string GetByAddress(string Address)
        {
            return Address + "kaddka";
        }

        // POST api/values
        public string Post([FromBody]MobileParameter mobile)
        {
            using (var db = new BloggingContext())
            {
                var query = from b in db.MemCards
                            where b.mobile == mobile.Mobile
                    select b;
                var memcards = query.ToList();
                if (memcards.Count < 1)
                {
                    var cardno= db.Database.SqlQuery<string>("select serialno from f_get_serialno('MEM')").First();
                    var newCardNum = AddNewMemCards(mobile.Mobile, cardno);

                    db.MemCards.Add(newCardNum);
                    memcards.Add(newCardNum);
                }
                var result = new Results
                {
                    Code = 0,
                    info = memcards,
                    msg = "成功"

                };
                return JsonConvert.SerializeObject(result); ;
            }
        }

        [Route("api/MemCards/update")]
        public string PostUpdate([FromBody] MemCard memCard)
        {
            using (var db = new BloggingContext())
            {
                try
                {

                    var query = from b in db.MemCards
                                where b.mobile == memCard.mobile
                        select b;
                    var memcards = query.ToList();
                    if (memcards.Count > 0)
                    {
                        var memcard = memcards[0];
                        memcard.Name = memCard.Name;
                        if (memCard.address != null)
                        {
                            memcard.address = memCard.address;
                        }
                        if (memCard.sex != null)
                        {
                            memcard.sex = memCard.sex;
                        }
                        if (memCard.birthday != null)
                        {
                            memcard.birthday = memCard.birthday;
                        }
                        
                    }

                    db.SaveChanges();
                    var result = new Results
                    {
                        Code = 0,
                        msg = "会员信息同步成功!"

                    };
                    return JsonConvert.SerializeObject(result);
                    ;
                }
                catch (Exception e)
                {
                    var result = new Results
                    {
                        Code = -1,
                        msg = "会员信息同步失败!"

                    };
                    return JsonConvert.SerializeObject(result);
                }
            }
        }

        private MemCard AddNewMemCards(string mobile,string newCardno)
        {
            //var newCardno = "e0582800";
            var memCards = new MemCard
            {
                Name = "",
                sex = "",
                certif_no = "",
                birthday = null,
                //email="",
                //lever="0",//default 0,--0会员卡 1贵宾卡
                state = 0, //default 0,    -- 0= 新发卡 1= 正常卡 9= 已删除
                address = "",
                Card_no = newCardno//会员卡号

            };
            return memCards;

        }

        



        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {

        }
    }
}
