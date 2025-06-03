using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd2
{
    class Shop
    {
        // private List<Product> products;
        private Dictionary<Product, int> products;
        private decimal profit; // прибыль
        private decimal check; // чек покупки
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
            string listProducts = "Список всех продуктов:\n ";
            foreach (var product in products)
            {
                //Console.WriteLine(product.GetInfo());
                listProducts += product.Key.GetInfo() + "; Количество: " + product.Value + "\n";
            }
            MessageBox.Show(listProducts);
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
                foreach (var product in products)
                {
                    if (product.Key.Name == ProductName && product.Value > 0)
                    {
                        products[product.Key]--; // уменьшение количества продукта
                        profit += product.Key.Price; // увеличение прибыли
                        check += product.Key.Price; // увеличение суммы чека покупки
                        MessageBox.Show($"Товар {ToSell.Name} продан успешно");
                        return;
                    }
                }
                MessageBox.Show("Товар закончился!");
                //this.Sell(ToSell.Name);
            }
            else
            {
                MessageBox.Show("Товар не найден!");
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
        public void SellProducts(string[] productNames) // продажа нескольких продуктов
        { 
            foreach (var name in productNames)
            {
                Sell(name);
            }
        }
        public decimal Profit() // прибыль магазина
        {
            return profit;
        }
        public decimal Check()
        {
            return check;
        }
        public void NewSell()
        {
            check = 0;
        }
    }
}
