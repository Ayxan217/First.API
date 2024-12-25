using First.API.Repositories.Interfaces;

namespace First.API.Repositories.Implementations
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context) { }
       
    }
}
