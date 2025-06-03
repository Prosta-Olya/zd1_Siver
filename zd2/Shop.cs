using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd2
{
    class Shop
    {
        // private List<Product> products;
        private Dictionary<Product, int> products;
        private decimal profit; // прибыль
        public Shop()
        {
            // products = new List<Product>();
            products = new Dictionary<Product, int>();
            profit = 0;
        }
        public void AddProduct(Product product, int count) // добавление продукта в список продуктов
        {
            products.Add(product, count);
            //products.Add(product);
        }
        public void WriteAllProducts() // вывод всех продуктов
        {
            Console.WriteLine("Список всех продуктов: ");
            foreach (var product in products)
            {
                //Console.WriteLine(product.GetInfo());
                Console.WriteLine(product.Key.GetInfo() + "; Количество: " + product.Value);
            }
        }
        public void CreateProduct(string name, decimal price, int count) // метод для создания продукта и добавления его в список
        {
            //Product product = new Product(name, price);
            //products.Add(product);
            products.Add(new Product(name, price), count);
        }
        public void Sell(string ProductName) // покупка товара
        {
            Product ToSell = FindByName(ProductName);
            if (ToSell != null)
            {
                foreach(var product in products)
                {
                    if(product.Key.Name==ProductName && product.Value > 0)
                    {
                        products[product.Key]--;
                        profit += product.Key.Price;
                    }
                }
                //this.Sell(ToSell.Name);
            }
            else
            {
                Console.WriteLine("Товар не найден!");
            }
        }
        public Product FindByName(string name) // поиск продукта по имени
        {
            foreach (var product in products.Keys)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }
            return null;
        }
        public decimal Profit()
        {
            return profit;
        }
    }
}
