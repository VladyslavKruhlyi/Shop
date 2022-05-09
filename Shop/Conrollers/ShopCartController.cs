using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.Data.Repository;
using Shop.ViewModels;
using System.Linq;

namespace Shop.Conrollers
{
    public class ShopCartController : Controller
    {
        private IPhone _phoneRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IPhone phoneRepository, ShopCart shopCart)
        {
            _phoneRepository = phoneRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;
            
            var obj = new ShopCartViewModel
                {
                ShopCart = _shopCart,

            };
            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _phoneRepository.GetAllPhones.FirstOrDefault(c => c.Id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
} 
