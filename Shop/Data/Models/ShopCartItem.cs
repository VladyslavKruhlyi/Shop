namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Phone Phone { get; set; }
        public int Price { get; set; }
        public string ShopPhoneId { get; set; }
    }
}
