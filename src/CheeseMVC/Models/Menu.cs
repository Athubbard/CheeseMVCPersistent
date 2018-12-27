using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        IList<CheeseMenu> CheeseMenus { get; set; }
    }
}

