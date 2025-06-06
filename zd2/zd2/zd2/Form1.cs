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
        private Playlist playlist;
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
            //pyaterochka.WriteAllProducts();

            playlist = new Playlist();
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

        private void button4_Click(object sender, EventArgs e) // начало новой покупки
        {
            pyaterochka.NewSell();
            MessageBox.Show("Вы можете начать новую покупку :)");
        }

        private void Form1_Load(object sender, EventArgs e) // при загрузке формы загружается панель с интерфейсом магазина
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }
        private void UpdateListBox() // обновление listBox с плейлистом
        {
            listBox1.Items.Clear();
            foreach (var song in playlist.AllSongs())
            {
                listBox1.Items.Add($"{song.Title} - {song.Author}");
            }
        }
        private void CurrentSong() // вывод текущей песни
        {
            try
            {
                var currentSong = playlist.CurrentSong();
                label1.Text = $"Текущая песня: {currentSong.Title} - {currentSong.Author}";
            }
            catch (Exception)
            {
                label1.Text = "Нет текущей песни!";
            }
        }
        private void button5_Click(object sender, EventArgs e) // добавление песни в плейлист
        {
            if(string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Для добавления песни в плейлист заполните все поля!");
            }
            else
            {
                playlist.AddSong(textBox2.Text, textBox3.Text, textBox4.Text);
                UpdateListBox();
            }
        }

        private void button6_Click(object sender, EventArgs e) // удаление песни
        {
            if (listBox1.SelectedIndex != -1)
            {
                playlist.RemoveSong(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                UpdateListBox();
            }
        }

        private void button11_Click(object sender, EventArgs e) // очистка плейлиста
        {
            playlist.ClearList();
            listBox1.Items.Clear();
            UpdateListBox();
            CurrentSong();
        }

        private void button7_Click(object sender, EventArgs e) // переход к следующей песне
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите строку в списке");
                return;
            }
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex > 0)
            {
                listBox1.SelectedIndex = selectedIndex - 1;
            }
            else
            {
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void button8_Click(object sender, EventArgs e) // переход к предыдущей песне
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите строку в списке");
                return;
            }
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex < listBox1.Items.Count - 1)
            {
                listBox1.SelectedIndex = selectedIndex + 1;
            }
            else
            {
                listBox1.SelectedIndex = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e) // переход к началу списка
        {
            listBox1.SelectedIndex = 0;
        }

        private void button9_Click(object sender, EventArgs e) // переход по индексу
        {
            int num = (int)numericUpDown1.Value;
            if (listBox1.Items.Count >= num)
            {
                listBox1.SelectedIndex = num;
            }
            else
            {
                MessageBox.Show("Число больше размера вашего плейлиста");
            }
        }

        private void магазинToolStripMenuItem_Click(object sender, EventArgs e) // выбор панели с интерфейсом магазина
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel1.BringToFront();
        }

        private void плейлистToolStripMenuItem_Click_1(object sender, EventArgs e) // выбор панели с интерфейсом плейлиста
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.BringToFront();
        }
    }
}
