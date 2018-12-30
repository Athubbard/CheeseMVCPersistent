using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace CheeseMVC.Controllers
{
    public class MenuController : Controller
    {
        private CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            IList<Menu> menus = context.Menus.ToList();

            return View(menus);

        }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu()
                {
                    Name = addMenuViewModel.Name
                };

                context.Menus.Add(newMenu);
                context.SaveChanges();
                return Redirect("/Menu/ViewMenu/" + newMenu.ID);

            }
            return View(addMenuViewModel);
        }
           
        [HttpGet]
            public IActionResult ViewMenu(int id)
        {
            
            List<CheeseMenu> items = context.CheeseMenu.Include(item => item.Cheese).Where(cm => cm.MenuID == id).ToList();

            Menu newMenu = context.Menus.Single(m => m.ID == id);

            ViewMenuViewModel viewModel = new ViewMenuViewModel
            {
                Menu = newMenu,
                Items = items,
            };
            return View(viewModel);
        }
            public IActionResult AddItem(int id)
        {   

            Menu Menu = context.Menus.SingleOrDefault(m => m.ID == id);
            List<Cheese> Cheeses = context.Cheeses.ToList();
            AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(Menu, Cheeses);
            return View(addMenuItemViewModel);
        }
            [HttpPost]
            public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var cheeseID = addMenuItemViewModel.cheeseID;
                var menuID = addMenuItemViewModel.menuID;
                IList<CheeseMenu> existingItems = context.CheeseMenu
                    .Where(cm => cm.CheeseID == cheeseID)
                    .Where(cm => cm.MenuID == menuID).ToList();
                if (existingItems.Count == 0)
                {
                    CheeseMenu menuItem = new CheeseMenu
                    {
                        Cheese = context.Cheeses.Single(c => c.ID == cheeseID),
                        Menu = context.Menus.Single(m => m.ID == menuID)
                    };
                    context.CheeseMenu.Add(menuItem);
                    context.SaveChanges();
                    return Redirect(string.Format("/Menu?ViewMenu/{0}", addMenuItemViewModel.menuID));
                }

               
            }return View(addMenuItemViewModel);
                
            }


        }
        }


   
