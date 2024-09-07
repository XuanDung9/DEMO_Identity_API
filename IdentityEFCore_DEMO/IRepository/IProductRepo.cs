using Data_DEMO.Models;

namespace IdentityEFCore_DEMO.IRepository
{
    public interface IProductRepo
    {
        public Task<List<ProductModel>> GetAllProductAsync();
        public Task<ProductModel> GetProductAsync(long id);
        public Task<long> AddProductAsync(ProductModel model);
        public Task UpdateProductAsync(long id, ProductModel model);
        public Task DeleteProductAsync(long id);
    }
}
