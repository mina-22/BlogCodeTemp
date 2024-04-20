using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Pages.Companies
{
    public class CreateModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company company { set; get; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _db.Companies.Add(company);
            _db.SaveChanges();
            return RedirectToPage("ViewCompany");
        }
    }
}
