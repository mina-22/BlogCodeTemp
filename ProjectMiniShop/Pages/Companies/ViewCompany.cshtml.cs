using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Pages.Companies
{
    public class ViewCompanyModel(ApplicationDbContext _db) : PageModel
    {
       
        public List<Company> AllCompany { set; get; }
        public void OnGet()
        {
            AllCompany=_db.Companies.ToList();
        }
        public IActionResult OnPostDelete(int id)
        {
            var company=_db.Companies.FirstOrDefault(m=>m.Id== id);
            _db.Companies.Remove(company);
            _db.SaveChanges();
            return RedirectToPage("ViewCompany");
        }
    }
}
