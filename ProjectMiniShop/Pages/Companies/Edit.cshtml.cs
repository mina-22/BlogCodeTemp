using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Pages.Companies
{
    public class EditModel(ApplicationDbContext _db) : PageModel
    {
        [BindProperty]
        public Company company { get; set; }
        public void OnGet(int id)
        {
            company = _db.Companies.SingleOrDefault(m => m.Id == id);
        }

        public IActionResult OnPost()
        {
            var oldCompany=_db.Companies.SingleOrDefault(m => m.Id == company.Id);
            oldCompany.Name=company.Name;
            _db.SaveChanges();
            return RedirectToPage("ViewCompany");
        }

    }
}
