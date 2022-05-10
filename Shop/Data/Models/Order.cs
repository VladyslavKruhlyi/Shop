using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; } 
        
        [Display(Name ="Enter name")]
        [StringLength(25)]
        [Required(ErrorMessage = "Lenght no less 5 symbols")]
        public string Name { get; set; }

        [Display(Name = "Enter surname")]
        [StringLength(25)]
        [Required(ErrorMessage = "Lenght no less 5 symbols")]
        public string SurName { get; set; }

        [Display(Name = "Enter adress")]
        [StringLength(35)]
        [Required(ErrorMessage = "Lenght no less 5 symbols")]
        public string Adress { get; set; }

        [Display(Name = "Enter phone")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Lenght no less 10 symbols")]
        public string Phone { get; set; }
        
        [Display(Name = "Enter email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Lenght no less 15 symbols")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
