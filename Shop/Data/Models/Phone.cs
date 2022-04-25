﻿namespace Shop.Data.Models
{
    public class Phone
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Image { get; set; }
        public ushort Price { get; set; }
        public bool IsFavorite { get; set; }
        public bool Avaliable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
