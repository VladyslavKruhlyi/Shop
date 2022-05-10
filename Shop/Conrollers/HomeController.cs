using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Conrollers
{
    public class HomeController : Controller
    {
        private IPhone _phoneRepository;

        public HomeController(IPhone phoneRepository)
        {
            _phoneRepository = phoneRepository;
        }

        public ViewResult Index()
        {
            var homePhones = new HomeViewModel
            {
                FavoritePhones = _phoneRepository.GetFavoritePhones
            };
            return View(homePhones);
        }

    }
}
