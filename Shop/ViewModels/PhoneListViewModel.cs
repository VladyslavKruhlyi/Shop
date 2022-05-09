using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.ViewModels
{
    public class PhoneListViewModel
    {
        public IEnumerable<Phone> AllPhones { get; set; }
        public string CurrentCategory { get; set; }
    }
}
