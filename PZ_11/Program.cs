namespace PZ_11
{
    internal class Program
    {
        static double GetArea(double a1, double a2, double b1, double b2)
        {
            if (a1 * a2 > b1 * b2)
                return 0;
            else if (a1 * a2 < b1 * b2)
                return 1;
            else
                return -1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 2 стороны первого прямоугольника");
            double a1 = Convert.ToDouble(Console.ReadLine());
            double a2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите 2 стороны второго прямоугольника");
            double b1 = Convert.ToDouble(Console.ReadLine());
            double b2 = Convert.ToDouble(Console.ReadLine());
            double result = GetArea(a1, a2, b1, b2);
            if (result == 0)
                Console.WriteLine("Первый прямоугольник больше второго(" + a1 + '*' + a2 + " > " + b1 + '*' + b2 + ")");
            else if (result == 1)
                Console.WriteLine("Второй прямоугольник больше второго(" + a1 + '*' + a2 + " < " + b1 + '*' + b2 + ")");
            else
                Console.WriteLine("Прямоугольники равны(" + a1 + '*' + a2 + " = " + b1 + '*' + b2 + ")");
        }
    }
}