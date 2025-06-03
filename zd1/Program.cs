using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    class Program
    {
        static void Main(string[] args)
        {
           

            //// задание 1 
            //Cat murzik = new Cat("Мурзик", 3.2);
            //Cat barsik = new Cat("Барсег", 2.5);
            //Cat barsik123 = new Cat("Барсик123", 4);
            //murzik.Meow();
            //murzik.Info();
            //barsik.Meow();
            //barsik.Info();
            //barsik.Name ="Барсик";
            //barsik.Meow();
            //barsik.Name = "1234";
            //barsik.Weight = 0;
            //barsik.Meow();

            Console.WriteLine("Введите имя и вес кота:");
            Cat cat = new Cat(Convert.ToString(Console.ReadLine()),Convert.ToDouble(Console.ReadLine()));
            cat.Meow();
            cat.Info();

            Console.ReadLine();
        }
    }
}
