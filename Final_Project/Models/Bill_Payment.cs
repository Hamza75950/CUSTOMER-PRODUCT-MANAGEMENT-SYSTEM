using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Final_Project.Models
{
    public class Bill_Payment
    {
        [Required(ErrorMessage = "Delivery Date is required.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }

        [Required(ErrorMessage = "Delivery Challan Number is required.")]
        public string Del_Challan { get; set; }

        public List<SelectListItem> CompList { get; set; }

        [Required(ErrorMessage = "Company Name is required.")]
        public string Company_Name { get; set; }

        public int Company_Code { get; set; }
        [Required(ErrorMessage = "Fabric Rolls is required.")]
        public string Rolls { get; set; }

        [Required(ErrorMessage = "Fabric Weight is required.")]
        public double weight { get; set; }

        [Required(ErrorMessage = "Fabric Colour is required.")]
        public string Colour { get; set; }

        [Required(ErrorMessage = "Fabric Name is required.")]
        public string fabric_name { get; set; }
        public int fb_ID { get; set; }


        [Required(ErrorMessage = "Fabric Price is required.")]
        public double Fab_Rate { get; set; }

        public double Amount { get; set; }
        public double Total_Amount { get; set; }

    }
}