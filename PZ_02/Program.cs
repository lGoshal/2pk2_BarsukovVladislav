namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x, y, z;
            Console.WriteLine("Введите переменную i");
            int i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите переменную j");
            double j = Convert.ToDouble(Console.ReadLine());
            if (i > 0)
            {
                x = i * j + Math.Sin(j);
            }
            else
            {
                x = i + j / Math.Sqrt(i + 2 * j);
            }
            if (x <= 6)
            {
                y = Math.Cos(i + x);
            }
            else
            {
                y = x + 15 * Math.Sqrt(x * 0.5 * j);
            }
            z = x + y / Math.Pow(x, 2) + Math.Pow(j, 2) + 1;
            Console.WriteLine("Вы ввели значения " + i + " и " + j);
            Console.WriteLine("Значение x = " + x);
            Console.WriteLine("Значение y = " + y);
            Console.WriteLine("Значение z = " + z);
        }
    }
}