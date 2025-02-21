using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productRepository.GetProductsAsync();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetProductBrands()
        {
            return Ok(await _productRepository.GetProductBrandAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetProductTypes()
        {
            return Ok(await _productRepository.GetProductTypeAsync());
        }
    }
}
