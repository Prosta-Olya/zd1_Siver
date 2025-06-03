using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            pyaterochka.Sell("Кола");
            pyaterochka.WriteAllProducts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] products = textBox1.Text.Split(new[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            pyaterochka.WriteAllProducts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Прибыль магазина: {pyaterochka.Profit()}");
        }
    }
}
