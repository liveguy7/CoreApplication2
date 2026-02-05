using CoreApplication2.Data.Interfaces;
using Microsoft.AspNetCore.SignalR;
using CoreApplication2.Data.Models;

namespace CoreApplication2.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;

        }
        public void CreateOrder(Order order)
        {
            order.OrderPlace = DateTime.Now;
            _appDbContext.OrderTarget.Add(order);

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var item in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = item.Amount,
                    CarId = item.Car.CarId,
                    OrderId = order.OrderId,
                    Price = item.Car.Price
                };
                _appDbContext.OrderDetailTarget.Add(orderDetail);

            }
            _appDbContext.SaveChanges();
        }

    }
}




















