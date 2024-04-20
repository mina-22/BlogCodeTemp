using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectMiniShop.Models;

namespace ProjectMiniShop.ViewModel
{
    public class ProductViewModel
    {
        public  Product Product { get; set; }
        public IEnumerable<SelectListItem> companies { get; set; }
    }
}
