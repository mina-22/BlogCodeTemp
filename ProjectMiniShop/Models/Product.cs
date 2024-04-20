using ProjectMiniShop.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ProjectMiniShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DeniedValues("AAA", "BBB")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "description is required")]
        [Length(5, 50)]
        [RegularExpression(@"^[a-zA-Z' '-'\s]{1,40}$",
            ErrorMessage = "Characters are not allowed.")]
        public string Description { get; set; }

        [Required]
        [Range(1, 50000, ErrorMessage = "please enter price from 1 to 50000")]
        [CheckMaxCompanyPrice(30000)]
        public float Price { get; set; }

        [Required]
        [Range(1, 3000, ErrorMessage = "please enter Quantity from 1 to 3000")]
        public int Quantity { get; set; }

        public bool EnableSize { get; set; }

        public float OldPrice { get; set; }

        [Required]
        public string Image {  get; set; }  
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company? Company { get; set; }
    }
}
