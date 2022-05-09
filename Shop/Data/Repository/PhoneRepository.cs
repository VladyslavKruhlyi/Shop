using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data.Repository
{
    public class PhoneRepository : IPhone
    {
        private readonly AppDBContent appDBContent;
        public PhoneRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Phone> GetAllPhones => appDBContent.Phone.Include(c => c.Category);

        public IEnumerable<Phone> GetFavoritePhones => appDBContent.Phone.Where(p => p.IsFavorite).Include(c => c.Category);

        public Phone GetPhoneById(int phoneId) => appDBContent.Phone.FirstOrDefault(p => p.Id == phoneId);
        
    }
}
