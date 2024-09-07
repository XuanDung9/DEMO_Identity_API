using AutoMapper;
using Data_DEMO.DataContext;
using Data_DEMO.Models;
using IdentityEFCore_DEMO.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace IdentityEFCore_DEMO.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductRepo( AppDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<long> AddProductAsync(ProductModel model)
        {
            var newProduct = _mapper.Map<Products>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct.Id;
        }

        public async Task DeleteProductAsync(long id)
        {
            var deleteItem = _context.Products.SingleOrDefault(p => p.Id == id);
            if (deleteItem != null)
            {
                _context.Products.Remove(deleteItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductModel>> GetAllProductAsync()
        {
            var lst_product = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(lst_product);
        }

        public async Task<ProductModel> GetProductAsync(long id)
        {
            var product = await _context.Products!.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task UpdateProductAsync(long id, ProductModel model)
        {
            if (id == model.Id)
            {
                var updateItem = _mapper.Map<Products>(model);
                _context.Products!.Update(updateItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
