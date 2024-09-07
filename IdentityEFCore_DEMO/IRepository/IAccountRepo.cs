using Data_DEMO.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityEFCore_DEMO.IRepository
{
    public interface IAccountRepo
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync( SignInModel model); // trả về True / False hoặc chuỗi Token
    }
}
