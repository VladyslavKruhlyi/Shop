using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface ICategory
    {
        IEnumerable<Category> GetAllCategories { get; }
    }
}
