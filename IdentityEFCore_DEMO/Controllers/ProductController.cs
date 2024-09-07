using Data_DEMO.Models;
using IdentityEFCore_DEMO.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IdentityEFCore_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo _repo;

        public ProductController(IProductRepo repo)
        {
            _repo = repo;
        }
        // GET: api/<ProductController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll () 
        {
            try
            {
                return Ok( await _repo.GetAllProductAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(long id)
        {
            var product = await _repo.GetProductAsync(id);
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create ( ProductModel model )
        {
            var newProduct = await _repo.AddProductAsync(model);
            return Ok(newProduct);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update (long id,[FromBody]  ProductModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            await _repo.UpdateProductAsync(id, model);
            return Ok();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute]long id)
        {
            await _repo.DeleteProductAsync(id);
            return Ok();
        }
    }
}
