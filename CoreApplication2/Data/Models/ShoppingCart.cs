using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CoreApplication2.Data.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };

        }
        public void AddToCart(Car car, int amount)
        {
            var shoppingCartItem =
                _appDbContext.shoppingTarget.SingleOrDefault(
                    s => s.Car.CarId == car.CarId && s.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Car = car,
                    Amount = 1
                };
                _appDbContext.shoppingTarget.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();

        }
        public int RemoveFromCart(Car car)
        {
            var shoppingCartItem =
                _appDbContext.shoppingTarget.SingleOrDefault(
                    s => s.Car.CarId == car.CarId && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.shoppingTarget.Remove(shoppingCartItem);
                }
            }
            _appDbContext.SaveChanges();

            return localAmount;

        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                  _appDbContext.shoppingTarget.Where(c =>
                      c.ShoppingCartId == ShoppingCartId)
                      .Include(s => s.Car)
                      .ToList());

        }

        public void ClearCart()
        {
            var cartItems = _appDbContext
                .shoppingTarget
                .Where(cart =>
                    cart.ShoppingCartId == ShoppingCartId);
            _appDbContext.shoppingTarget.RemoveRange(cartItems);

            _appDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _appDbContext.shoppingTarget.Where(c =>
                      c.ShoppingCartId == ShoppingCartId)
                      .Select(c =>
                             c.Car.Price * c.Amount).Sum();
            return total;
        }

    }
}



























































