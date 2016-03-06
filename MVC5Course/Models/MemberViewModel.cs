using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Course.Models
{
    public class MemberViewModel
    {
        public int id { get; set; }

        [Required]
        public String name { get; set; }
        [Required]
        public DateTime birthday { get; set; }
    }
}