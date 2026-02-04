using CoreApplication2.Data.Interfaces;
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

        public ViewResult List()
        {
            CarListViewModel cm = new CarListViewModel();
            cm.Cars = _carRepository.Cars;
            cm.CurrentCategory = "Car Category";

            return View(cm);

        }
        
    }
}



















