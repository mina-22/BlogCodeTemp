using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.Pages.CompaniesWithSca
{
    public class IndexModel : PageModel
    {
        private readonly ProjectMiniShop.Data.ApplicationDbContext _context;

        public IndexModel(ProjectMiniShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Company = await _context.Companies.ToListAsync();
        }
    }
}
