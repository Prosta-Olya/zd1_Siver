using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zd2
{
    public partial class Form1 : Form
    {
        private Shop pyaterochka;
        public Form1()
        {
            InitializeComponent();

            //Product cola = new Product("Кола", 85);
            //Product juice = new Product("Сок \"Добрый\"", 100);
            //Console.WriteLine(cola.GetInfo());
            //Console.WriteLine(juice.GetInfo());

            pyaterochka = new Shop();
            pyaterochka.CreateProduct("Кола", 85, 200);
            pyaterochka.CreateProduct("Сок \"Добрый\"", 100, 50);
            pyaterochka.WriteAllProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] productsToSell = textBox1.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries); // список товаров

            pyaterochka.SellProducts(productsToSell.Select(p => p.Trim()).ToArray()); // продажа

            pyaterochka.WriteAllProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Текущая прибыль: {pyaterochka.Profit()} руб."); // вывод прибыли магазина
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Сумма чека вашей покупки: {pyaterochka.Check()} руб."); // вывод суммы чека покупки
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pyaterochka.NewSell();
            MessageBox.Show("Вы можете начать новую покупку :)");
        }
    }
}
