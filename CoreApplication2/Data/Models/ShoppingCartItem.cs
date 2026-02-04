namespace CoreApplication2.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Car Car { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
