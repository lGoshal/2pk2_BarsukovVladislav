using System.ComponentModel.Design;

namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)// Задание номер 1
        {
            /*
                Console.WriteLine("Введите порядковый номер числа: ");
                double n = Convert.ToDouble(Console.ReadLine());
                double a = 9;
                double b = 0.5;
                double result = Regress(n, a, b);
                Console.WriteLine($"{i} член прогрессия равен {a}");
            
            Задание номер 2
            
                Console.WriteLine("Введите порядковый номер числа: ");
                double n = Convert.ToDouble(Console.ReadLine());
                double b = 5;
                double q = -0.1;
                double result = RegressDel(n, b, q);
                Console.WriteLine($"{n} Член прогрессии равен {result}");
            
            Задание номер 3
            
            int a = 6;
            int b = 78+1;
            if (a < b)
            {
                RegressSum(a, b);
            }
            else
            {
                RegressSum1(a, b);
            }
            
            //Задание номер 4(1)

            Console.WriteLine("Введите число: ");
            int n = int.Parse(Console.ReadLine());
            int a = 0;
            int result = RegressRek(n, a);
            */
        }
        //Методы
        //Метод для 1 задачи
        static double Regress(double n, double a, double b)
        {
            if (n == 1)
            {
                Console.WriteLine($"{n} Член прогресси равен {a}");
            }
            else
            {
                a += b;
            }
            return Regress(n - 1, a, b);
        }

        //Метод для 2 задачи
        static double RegressDel(double n, double b, double q)
        {
            if (n == 1)
            {
                Console.WriteLine($"{n} Член прогрессии равен {b}");
            }
            else
            {
                b /= q;
            }
            return RegressDel(n - 1, b, q);
        }
        //Метод для 3 задачи при условии a < b
        static void RegressSum(double a, double b)
        {
            if (a < b)
            {
                Console.WriteLine(a);
                a++;
                RegressSum(a, b);
            }
        }
        //Метод для 3 задачи при условии a > b
        static void RegressSum1(double a, double b)
        {
            if (a > b)
            {
                Console.WriteLine(a);
                a--;
                RegressSum1(a, b);
            }
        }
        
        static int RegressRek(int n, int a)
        {
            if (n == 1)
            {
                Console.WriteLine($"Прогрессия числа равна {a + 1}");
            }
            else
            {
                a += n;
                RegressRek(n - 1, a);
            }
            return a;
        }
    }
}