using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Final_Project.Models
{
    public class Bill_Payment
    {
        [Required(ErrorMessage = "Delivery Date is required.")]
        public DateTime Date { get; set; }
        
        [Required(ErrorMessage = "Delivery Challan Number is required.")]
        public string Del_Challan { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        public string Company_Name { get; set; }
        
        [Required(ErrorMessage = "Fabric Rolls is required.")]
        public string Rolls { get; set; }
        
        [Required(ErrorMessage = "Fabric Weight is required.")]
        public decimal weight { get; set; }
        
        [Required(ErrorMessage = "Fabric Colour is required.")]
        public string Colour { get; set; }
        
        [Required(ErrorMessage = "Fabric Name is required.")]
        public string Fabric { get; set; }
       
        [Required(ErrorMessage = "Fabric Price is required.")]
        public int Fab_Rate { get; set; }
    }
}