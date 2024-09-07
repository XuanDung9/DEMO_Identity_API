using Data_DEMO.Models;
using IdentityEFCore_DEMO.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityEFCore_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepo _repo;

        public AccountController(IAccountRepo repo)
        {
            _repo = repo;
        }
        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var result = await _repo.SignUpAsync(model);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            var result = await _repo.SignInAsync(model);
            if(string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }    
            return Ok(result);
        }
           
    }
}
