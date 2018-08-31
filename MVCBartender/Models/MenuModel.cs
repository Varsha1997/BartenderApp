using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCBartender.Models
{
    public class MenuModel
    {
        public int Id { get; set; }

        [Display(Name="Drink")]
        public string CustomerDrink { get; set; }

        [Display(Name ="Price")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal CustomerDrinkPrice { get; set; }
    }
}