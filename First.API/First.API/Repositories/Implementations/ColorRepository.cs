using First.API.Repositories.Interfaces;

namespace First.API.Repositories.Implementations
{
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context) : base(context) { }
    }
}
