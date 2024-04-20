using AutoMapper;
using ProjectMiniShop.Models;
using ProjectMiniShop.Models.DTO;
namespace ProjectMiniShop
{
    public class MappingConf : Profile
    {
        public MappingConf() 
        {
            CreateMap<Product,ProductDTO>().ReverseMap();
            //CreateMap<ProductDTO,Product>();
        }
    }
}
