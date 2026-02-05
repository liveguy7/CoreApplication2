using CoreApplication2.Data.Interfaces;
using CoreApplication2.Data.Models;
using CoreApplication2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication2.Controllers
{
    public class CarController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICarRepository _carRepository;

        public CarController(ICategoryRepository categoryRepository, ICarRepository carRepository)
        {
            _categoryRepository = categoryRepository;
            _carRepository = carRepository;

        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Car> cars;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                cars = _carRepository.Cars.OrderBy(x => x.CarId);
                currentCategory = "All Cars";

            }
            else
            {
                if (string.Equals("SportsCar", _category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _carRepository.Cars.Where(p => p.Category.CategoryName.Equals("SportsCar")).OrderBy(x => x.Name);
                    currentCategory = _category;

                }
                else
                {
                    cars = _carRepository.Cars.Where(p => p.Category.CategoryName.Equals("SuperSportsCar")).OrderBy(x => x.Name);
                    currentCategory = _category;

                }

            }
            var carListViewModel = new CarListViewModel
            {
                Cars = cars,
                CurrentCategory = currentCategory
            };

            return View(carListViewModel);


            //CarListViewModel cm = new CarListViewModel();
            //cm.Cars = _carRepository.Cars;
            //cm.CurrentCategory = "Car Categories";

            //return View(cm);

        }

    }
}



















