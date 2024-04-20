using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;
using System.Diagnostics;

namespace ProjectMiniShop.Controllers
{
    public class HomeController(ApplicationDbContext _db) : Controller
    {
       

     
        public IActionResult Index()
        {

            return View(_db.Products.Include(m=>m.Company).ToList());
        }

        public IActionResult About()
        {
            return View();
        }
        
          [HttpGet]
         public IActionResult Blog()
         {
            var blogs = _db.Blogs.ToList();

             return View(blogs);
         }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitForm(ContactForm model)
       {
            if (!ModelState.IsValid)
            {
                return View("Contact", model);
            }
            _db.ContactForm.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Contact");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
