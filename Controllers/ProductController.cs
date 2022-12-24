using AutoMapper;
using CapstoneBackend.Data;
using CapstoneBackend.DTOs;
using CapstoneBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapstoneBackend.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController : ControllerBase
{
    //Service Dependencies injected
    private readonly ProductContext _dbContext;
    private readonly IMapper _Mapper;
    //Inject our product context into the local db context
    public ProductController(ProductContext productContext, IMapper mapper)
    {
        _dbContext = productContext;
        _Mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
    {
        try
        {
            if (_dbContext.Products is null)
            {
                return NotFound();
            }

            return Ok(await _dbContext.Products.ToListAsync());
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProductById([FromRoute] int id)
    {
        try
        {
            var product = await _dbContext.FindAsync<Product>(id);

            if (product is null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct(ProductDTO productDTO)
    {
        try
        {
            if (_dbContext.Products is null)
            {
                return NotFound();
            }
            //Maps dto to Product
            var product = _Mapper.Map<Product>(productDTO);

            _dbContext.Products.Add(product);

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}