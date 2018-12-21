using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }

        IList<CheeseMenu> CheeseMenus = new List<CheeseMenu>();

        public static implicit operator string(Menu v)
        {
            throw new NotImplementedException();
        }
    }
}
