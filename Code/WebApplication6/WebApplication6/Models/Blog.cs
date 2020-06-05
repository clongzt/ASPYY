using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WebApplication6.Models
{
    public partial class Blog
    {
        public Blog()
        {
            //Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Url { get; set; }

        //[JsonIgnore]
       // public virtual ICollection<Post> Posts { get; set; }
    }

}