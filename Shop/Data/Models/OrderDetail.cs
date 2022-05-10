namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PhoneId { get; set; }
        public uint Price { get; set; }
        public virtual Order Order { get; set; }
        public virtual Phone Phone { get; set; }
    }
}
