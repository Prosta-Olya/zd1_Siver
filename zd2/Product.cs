using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2
{
    class Product
    {
        public decimal Price { get; set; } // цена
        public string Name { get; set; } // наименование
        public Product(string Name, decimal Price) // конструктор
        {
            this.Name = Name;
            this.Price = Price;
        }
        public string GetInfo() // информация о товаре
        {
            return $"Наименование: {Name}; Цена: {Price} руб.";
        }
    }
}
