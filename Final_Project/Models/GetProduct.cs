using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final_Project.Models
{
    public class GetProduct
    {
        [Required]
        public string fb_ID { get; set; }
        [Required]
        public string fabric_name { get; set; }
    }
}