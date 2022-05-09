using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;

namespace Shop.Conrollers
{
    public class PhoneController : Controller
    {
        private readonly IPhone _allPhones;
        private readonly ICategory _allCategory;

        public PhoneController(IPhone iPhones, ICategory iCategory)
        {
            _allPhones = iPhones;
            _allCategory = iCategory;
        }
        
        public ViewResult PhoneList()
        {
            ViewBag.Title = "Page with phone";
            PhoneListViewModel phones = new PhoneListViewModel
            {
                AllPhones = _allPhones.GetAllPhones,
                CurrentCategory = "Category"
            };
            return View(phones);
        }
    }
}
