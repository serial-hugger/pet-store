namespace pet_store.Data;

public class ProductRepository : IProductRepository
{
        private readonly DbContext _context;
        public ProductRepository()
        {
            _context = new DbContext();
        }

        
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public Product GetProductById(int id)
        {
            return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
}