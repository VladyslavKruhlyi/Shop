using Shop.Data.Models;

namespace Shop.Data.Interfaces
{
    public interface IOrder
    {
        void CreateOrder(Order order); 
    }
}
