using CoreApplication2.Data.Models;

namespace CoreApplication2.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> Cars { get; set; }

        public string CurrentCategory { get; set; }
    }
}



