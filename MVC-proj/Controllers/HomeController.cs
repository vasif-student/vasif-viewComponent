using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_proj.DAL;
using MVC_proj.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_proj.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new HomeIndexViewModel
            {
                Products = _context.Products.Include(p => p.Category).ToList(),
                Categories = _context.Categories.FirstOrDefault(),
                Blogs = _context.Blogs.ToList(),
                Says = _context.Says.ToList()
            });
        }
    }
}
