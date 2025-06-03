using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    class Cat
    {
        private string name; // имя кота скрытое поле
        private double weight; // вес кота скрытое поле
        public string Name // свойство имя кота
        {
            get
            {
                return name;
            }
            set
            {
                bool OnlyLetters = true;
                foreach (var ch in value)
                {
                    if (!char.IsLetter(ch))
                    {
                        OnlyLetters = false;
                    }
                }
                if (OnlyLetters)
                    name = value;
                else
                    Console.WriteLine($"{value} - неправильное имя!!!");
            }
        }
        public double Weight // свойство вес кота
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else
                {
                    Console.WriteLine($"{value} - неправильный вес!!!");
                }
            }
        }
        public Cat(string CatName) // конструктор для создания нового экземпляра
        {
            Name = CatName;
        }
        public Cat(string CatName, double WeightCat) // перегрузка конструктора
        {
            Name = CatName;
            Weight = WeightCat;
        }

        public void Meow() // метод для опознания отдельно взятого кота
        {
            Console.WriteLine($"{name}: МЯЯЯЯУ!!!!");
        }
        public void Info() // узнать вес кота
        {
            if (weight > 0)
            {
                Console.WriteLine($"Вес кота {name} = {weight}");
            }
        }
        public void SetCatName(string CatName) // имя кота не содержит какие-либо символы, кроме букв
        {
            bool OnlyLetters = true;
            foreach (var ch in CatName)
            {
                if (!char.IsLetter(ch))
                {
                    OnlyLetters = false;
                }
            }
            if (OnlyLetters)
                name = CatName;
            else
                Console.WriteLine($"{CatName} - неправильное имя!!!");
        }
    }
}
