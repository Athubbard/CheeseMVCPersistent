using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Data;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace CheeseMVC.Controllers
{
    public class MenuController: Controller
    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View(context.Categories.ToList());

        }
        [HttpGet]
        public IActionResult Add()
        {

        }

    }
}
