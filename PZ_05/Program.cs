using System.ComponentModel.Design;

namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            Console.WriteLine("Введите максимальное значение переменной (50)");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значение переменной (2)");
            int c = Convert.ToInt32(Console.ReadLine());
            while (a <= b)
            {
                Console.WriteLine(a);
                a *= c;
            }
            //Надеюсь это не возведение в степень), работает не только для 2 но и для других значений.
        }
    }
}