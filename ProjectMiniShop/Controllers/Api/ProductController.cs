using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectMiniShop.Data;
using ProjectMiniShop.Models;
using ProjectMiniShop.Models.DTO;

namespace ProjectMiniShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ApplicationDbContext _db,IMapper _Mapper) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(List<ProductDTO>))]
        public IActionResult getProduct()
        {
            var products = _db.Products.Include(m => m.Company)/*.Select(m=>new ProductDTO
            {
                Id=m.Id,
                Name=m.Name,
                Description=m.Description,
                Company=m.Company,
                CompanyId=m.CompanyId,
                Price=m.Price      
            })*/.ToList();
            //return Ok(products);
            return Ok(_Mapper.Map<List<ProductDTO>>(products));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult getProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.Company).SingleOrDefault(m => m.Id == id);

            if (products == null)
                return NotFound();
            //var productDto = new ProductDTO
            //{
            //    Name=products.Name,
            //    Id=products.Id, 
            //    Price=products.Price,
            //    Description=products.Description, 
            //    Company=products.Company,
            //    CompanyId=products.CompanyId,
            //};

            return Ok(_Mapper.Map<ProductDTO>(products));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddProduct(ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //var product=new Product()
            //{
            //    Name=productDto.Name,
            //    Price=productDto.Price,
            //    Description=productDto.Description,
            //    CompanyId=productDto.CompanyId, 
            //    EnableSize=false,
            //    Quantity=10,
            //};
            var product=_Mapper.Map<Product>(productDto);
            product.EnableSize = false;
            product.Quantity = 10;
            _db.Products.Add(product);
            _db.SaveChanges();
            return Ok();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var products = _db.Products.Include(m => m.Company).
                SingleOrDefault(m => m.Id == id);
            if (products == null)
                return NotFound();
            _db.Products.Remove(products);
            _db.SaveChanges();
            return Ok();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateProduct(ProductDTO UpdatedproductDto)
        {
            if (UpdatedproductDto.Id <= 0 && !ModelState.IsValid)
            {
                return BadRequest();
                
            }
            //var product=_db.Products.Include(m => m.Company).FirstOrDefault(m=>m.Id== UpdatedproductDto.Id);
            //if (product == null)
            //    return NotFound();
            //product.Name = UpdatedproductDto.Name;
            //product.Description = UpdatedproductDto.Description;
            //product.Price = UpdatedproductDto.Price;
            //product.CompanyId = UpdatedproductDto.CompanyId;
            var product = new Product();
             _Mapper.Map<ProductDTO,Product>(UpdatedproductDto,product);
            _db.SaveChanges();
            return Ok();
        }
    }
}
