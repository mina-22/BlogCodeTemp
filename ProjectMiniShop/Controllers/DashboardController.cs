using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;
using ProjectMiniShop.Utility;
using ProjectMiniShop.ViewModel;

namespace ProjectMiniShop.Controllers
{
    [Authorize(Roles ="Admin ,Employee")]
    public class DashboardController : Controller
    {
      
        private readonly ApplicationDbContext _db;

        public DashboardController(ApplicationDbContext db)
        {
            
            _db = db;

        }
        public IActionResult Index()
        {

            return View();
        }
        #region addProduct
        [Authorize(Roles =RL.RoleAdmin)]
        public IActionResult AddProduct()
        {
            var product = new ProductViewModel()
            {
                companies = _db.Companies.Select(m => new SelectListItem()
                {
                    Value = m.Id.ToString(),
                    Text = m.Name
                })
            };
            return View(product);
        }
        [HttpPost]
        [Authorize(Roles = RL.RoleAdmin)]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                var product1 = new ProductViewModel()
                {
                    Product=product,
                    companies = _db.Companies.Select(m => new SelectListItem()
                    {
                        Value = m.Id.ToString(),
                        Text = m.Name
                    })
                };
                return View(product1);
            }
            
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("GetProduct");
        }
        #endregion
        #region GetProduct
        [Authorize(Roles = RL.RoleEmployee)]
        public IActionResult GetProduct()
        {
            var product = _db.Products.Include(p => p.Company).ToList();
            return View(product);
        }

        #endregion
        #region Remove
        
        public IActionResult DeleteProduct(int id)
        {
            Product? product = _db.Products.Find(id);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return RedirectToAction("GetProduct");
            }
            return RedirectToAction("GetProduct");
        }
        #endregion
        #region EditProduct
        public IActionResult EditProduct(int? id)
        {
            Product? product = _db.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Product? product = _db.Products.SingleOrDefault(p => p.Id == model.Id);
            product.EnableSize = model.EnableSize;
            product.Price = model.Price;
            product.Description = model.Description;
            product.Name = model.Name;
            product.CompanyId = model.CompanyId;
            product.Quantity = model.Quantity;
            _db.Products.Update(product);
            _db.SaveChanges();
            return RedirectToAction("GetProduct");
        }
        #endregion
    }
}
