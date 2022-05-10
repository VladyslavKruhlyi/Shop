using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Linq;

namespace Shop.Conrollers
{
    public class OrderController : Controller
    {
        private readonly IOrder order;
        public readonly ShopCart shopCart;
        public OrderController(IOrder order, ShopCart shopCart)
        {
            this.order = order;
            this.shopCart = shopCart;
        }
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order orderCheckout)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();
            if (shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Add items in shop cart");
            }

            if (ModelState.IsValid)
            {
                order.CreateOrder(orderCheckout);
                return RedirectToAction("Complete");
            }

            return View(orderCheckout);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Order successful created";
            return View();
        }
    }
}
