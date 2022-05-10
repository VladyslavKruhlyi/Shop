using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;

namespace Shop.Data.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly AppDBContent appDBContent;
        public readonly ShopCart shopCart;
        public OrderRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            appDBContent.Order.Add(order);
            appDBContent.SaveChanges();

            var items = shopCart.ListShopItems;
            foreach (var item in items)
            {
                var orderDetail = new OrderDetail
                {
                    PhoneId = item.Phone.Id,
                    OrderId = order.Id,
                    Price = item.Phone.Price

                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
