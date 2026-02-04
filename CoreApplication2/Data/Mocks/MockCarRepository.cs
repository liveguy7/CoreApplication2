using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Mocks
{
    public class MockCarRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        
        public IEnumerable<Car> Cars
        {
            get
            {
                return new List<Car>
                {
                    new Car
                    {
                        Name = "Sport1",
                        Price = 44545M,
                        ShortDescription = "Fast and Light",
                        InStock = true,
                        IsPreferredColor = true
                    },
                    new Car
                    {
                        Name = "Sport2",
                        Price = 34342M,
                        ShortDescription = "Fast",
                        InStock = true,
                        IsPreferredColor = true

                    }
                };
            }
        }


    }
}
