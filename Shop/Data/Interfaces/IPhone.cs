using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IPhone
    {
        IEnumerable<Phone> GetAllPhones { get; }
        IEnumerable<Phone> GetFavoritePhones { get; }
        Phone GetPhoneById(int phoneId);
    }
}
  