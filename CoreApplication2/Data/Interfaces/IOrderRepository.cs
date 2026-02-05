using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
