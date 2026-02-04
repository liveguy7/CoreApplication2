using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryName="Sport", Description="All Sports Cars"},
                    new Category{CategoryName="NonSport", Description="All Regular Cars"}
                };
            }
        }

    }
}
