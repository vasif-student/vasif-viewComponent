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
    public class ProductController : Controller
    {
        private AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Skip(4).Take(4).Include(p => p.Category).ToList();
            ViewBag.skipCount = products.Count;

            return View(new ProductIndexViewModel
            {
                Products = products,
                Categories = _context.Categories.FirstOrDefault()
            });
        }

        public IActionResult LoadMore(int skipCount)
        {
            var products = _context.Products.Skip(skipCount).Take(4).Include(p => p.Category).ToList();
            return PartialView("_PartialProduct", products);
        }
    }
}
