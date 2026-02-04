using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> Cars { get; }

        //IEnumerable<Car> PreferredCars { get; set; }

        //Car GetCarById(int carId);

    }
}

