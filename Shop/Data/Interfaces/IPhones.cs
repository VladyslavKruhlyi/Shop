using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IPhones
    {
        IEnumerable<Phone> GetAllPhones { get; set; }
        IEnumerable<Phone> GetFavoritePhones { get; set; }
        Phone GetPhoneById(int phoneId);
    }
}
 