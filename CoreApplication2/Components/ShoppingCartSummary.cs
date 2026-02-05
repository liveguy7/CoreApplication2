using CoreApplication2.Data.Models;
using CoreApplication2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CoreApplication2.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;

        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();

            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new CoreApplication2.ViewModels.ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };
            
            return View(shoppingCartViewModel);
        }

    }
}
















