using CheeseMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CheeseMVC.ViewModels
{
    public class ViewMenuViewModel
    {
        [Required]
        [Display(Name = "Cheese")]
        public int cheeseID { get; set; }
        public int menuID { get; set; }

        public Menu Menu { get; set; }
        public string Name { get; set; }
        public IList<CheeseMenus> Items { get; set; }
    }
}
