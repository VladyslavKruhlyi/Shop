using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.Phone.Any())
            {
                content.Phone.AddRange(Phones.Select(c => c.Value));
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Phone> phone;
        public static Dictionary<string, Phone> Phones
        {

            get
            {
                if (phone == null)
                {
                    var list = new Phone[]
                        {
                            new Phone{Name = "IPhone 13", 
                                ShortDescription = "IPhoneShortDescription",
                                LongDescription = "IPhoneLongDescription",
                                Image = "/img/iphone.png", 
                                Price = 40000,IsFavorite = true,
                                Avaliable = true,
                                Category = DBObjects.Categories.Select(c =>c.Value).FirstOrDefault()},
                            new Phone{Name = "Samsung S21", 
                                ShortDescription = "SamsungShortDescription", 
                                LongDescription = "SamsungLongDescription",
                                Image = "/img/samsung.png",
                                Price = 30000,
                                IsFavorite = false,
                                Avaliable = false,
                                Category = Categories["Samsung"]}
                        };
                    phone = new Dictionary<string, Phone>();
                    foreach (var item in list)
                    {
                        phone.Add(item.Name, item);
                    }
                }
                return phone;
            }
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {

            get
            {
                if (category == null)
                {
                    var list = new Category[]
                        {
                            new Category{CategoryName ="IPhone", Description ="IPhoneDescription"},
                            new Category{CategoryName ="Samsung", Description ="SamsungDescription"}
                        };
                    category = new Dictionary<string, Category>();
                    foreach (var item in list)
                    {
                        category.Add(item.CategoryName, item);
                    }
                }
                return category;
            }
        }
    }
}
