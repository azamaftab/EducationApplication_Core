using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Education.Web.Models;
using Education.Data;
using Microsoft.EntityFrameworkCore;

namespace Education.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly EducationContext _context;

        public HomeController(EducationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //HomeViewModel homeViewModel = new HomeViewModel();
            //var educationContext = _context.Classes.Include(s => s.Students).Include(t => t.Teachers);
            //var result = await educationContext.ToListAsync();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
