using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApplication2.Data.Repositories
{
    public class CarRespository : ICarRepository
    {
        private readonly AppDbContext _appDbContext;
        public CarRespository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Car> Cars => _appDbContext.carTarget.Include(c => c.Category);

        public IEnumerable<Car> PreferredCars =>
            _appDbContext.carTarget.Where(p =>
                  p.IsPreferredColor).Include(c => c.Category);

        public Car GetCarById(int carId) =>
            _appDbContext.carTarget.FirstOrDefault(p =>
                    p.CarId == carId);

    }
}







