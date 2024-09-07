using Data_DEMO.Models;
using IdentityEFCore_DEMO.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityEFCore_DEMO.Repository
{
    public class AccountRepo : IAccountRepo
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;

        // sử dụng một số phương thức có sẵn chỉ cần inject ra dùng 
        public AccountRepo(UserManager<User> userManager , SignInManager<User> signInManager , IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid)
            {
                return string.Empty;
            }

            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Email , model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var authenKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken(
                issuer: configuration["JWT: ValidIssuer"],
                audience: configuration["JWT: ValidAudience"],
                expires: DateTime.Now.AddMinutes(10), // time hết hạn token 
                claims: authClaim,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature) // MÃ HÓA
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            try
            {
                var user = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };
                return await userManager.CreateAsync(user, model.Password);
            }
            catch (Exception ex)
            {
                // Log exception
                Console.WriteLine($"Error in SignUpAsync: {ex.Message}");
                throw; // Re-throw để giữ nguyên stack trace
            }
        }
    }
}
