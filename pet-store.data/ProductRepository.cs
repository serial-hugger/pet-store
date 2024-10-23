using Microsoft.EntityFrameworkCore;

namespace pet_store.Data;

public class ProductRepository : IProductRepository
{
        private readonly DbContext _context;
        public ProductRepository()
        {
            _context = new DbContext();
        }
        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.Where(p => p.ProductId == id).FirstOrDefaultAsync();
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
}