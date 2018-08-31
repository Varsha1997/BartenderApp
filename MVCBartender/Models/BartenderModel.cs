using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCBartender.Models
{
    public class BartenderModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Patron name is required.")]
        [Display(Name = "Patron Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Patron name is required.")]
        [Display(Name = "Drink")]
        public string CustomerDrinkName { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal CustomerDrinkPrice { get; set; }
    }
}