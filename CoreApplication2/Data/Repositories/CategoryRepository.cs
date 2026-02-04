using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> Categories => _appDbContext.categoryTarget;


    }
}
