using System.ComponentModel.DataAnnotations;

namespace ProjectMiniShop.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(2)]
        public string Title { get; set; }
        [Required]
        public string Discribtion { get; set; }
        [Required]
        public string image { get; set; }
		[Required]

		public int Coments { get; set; }    
    }
}
