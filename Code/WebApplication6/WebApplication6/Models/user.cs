using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class user
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
    }
}