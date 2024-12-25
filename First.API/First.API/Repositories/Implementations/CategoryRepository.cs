using First.API.Repositories.Interfaces;

namespace First.API.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext context):base(context) { }
      
    }
}
