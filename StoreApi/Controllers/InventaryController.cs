using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StoreApi.Data;
using StoreApi.Dto;
using StoreApi.Entities;
using StoreApi.Models;


namespace StoreApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InventaryController : Controller
    {
        private readonly AppDbContext _context;

        public InventaryController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsWithBatch()
        {
            var batch = await _context.Batches.ToListAsync();
            if (batch == null)
                return NotFound(); // No batch found
            var products = await _context.Products.ToListAsync();
            if (products == null)
                return NotFound(); // No products found

            var productsDTO = batch.Select(b =>
            {
                var product = products.FirstOrDefault(p => p.IdProduct == b.IdProduct);
                return new ProductDTO
                {
                    IdProduct = b.IdProduct,
                    Name = product?.Name ?? string.Empty,
                    Description = product?.Description ?? string.Empty,
                    Price = b.Price,
                    IdBatch = b.IdBatch,
                    Quantity = b.Quantity,
                };
            }).ToList();
            return productsDTO;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductWithBatch(int id)
        {
            var batch = await _context.Batches.FirstOrDefaultAsync(p => p.IdBatch == id);
            if (batch == null)
                return NotFound(); // No batch found

            var product = await _context.Products.FirstOrDefaultAsync(p => p.IdProduct == batch.IdProduct);
            if (product == null)
                return NotFound(); // No product found

            var productDTO = new ProductDTO
            {
                IdProduct = product.IdProduct,
                Name = product.Name,
                Description = product.Description,
                Price = batch.Price,
                IdBatch = batch.IdBatch,
                Quantity = batch.Quantity,
            };

            return Ok(productDTO);
        }
    }
}
