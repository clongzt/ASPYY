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
    public class UsersController : ApiController
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

        [Route("api/Address")]
        public string GetByAddress(string Address)
        {
            return Address + "kaddka";
        }

        [Route("api/users/update")]
        // POST api/values
        public void Post([FromBody]string value)
        {
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
