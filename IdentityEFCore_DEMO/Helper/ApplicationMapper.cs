using AutoMapper;
using Data_DEMO.Models;

namespace IdentityEFCore_DEMO.Helper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        { 
            CreateMap<Products, ProductModel>().ReverseMap(); // MAP 2 CHIỀU 
        }
    }
}
