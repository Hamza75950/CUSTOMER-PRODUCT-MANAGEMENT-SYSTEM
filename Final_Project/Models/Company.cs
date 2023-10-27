using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Company
    {
        [Required(ErrorMessage = "Company Code is required.")]
        public string Company_Code { get; set; }
        [Required(ErrorMessage = "Company Name is required.")]
        public string Company_Name { get; set; }    
        public string Company_Contact { get; set; }
        public string Company_Address { get; set; }

    }
}