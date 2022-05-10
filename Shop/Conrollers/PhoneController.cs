using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        [Route("Phone/PhoneList")]
        [Route("Phone/PhoneList/{category}")]
        public ViewResult PhoneList(string category)
        {
            string _categoty = category;
            IEnumerable<Phone> phones = null;
            string phoneCategory = string.Empty;
            if (string.IsNullOrEmpty(_categoty))
            {
                phones = _allPhones.GetAllPhones.OrderBy(i => i.Id);
            }
            else
            {
                if (string.Equals("IPhone", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    phones = _allPhones.GetAllPhones.Where(c => c.Category.CategoryName.Equals("IPhone")).OrderBy(i => i.Id);
                }
                if (string.Equals("Samsung", category, System.StringComparison.OrdinalIgnoreCase))
                {
                    phones = _allPhones.GetAllPhones.Where(c => c.Category.CategoryName.Equals("Samsung")).OrderBy(i => i.Id);
                }
                phoneCategory = _categoty;

                
            }
            PhoneListViewModel phonesOblect = new PhoneListViewModel
            {
                AllPhones = phones,
                CurrentCategory = phoneCategory
            };


            ViewBag.Title = "Page with phone";
            return View(phonesOblect);
        }
    }
}
