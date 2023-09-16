namespace PZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Пользователь вводит данные//
            Console.WriteLine("Введите значение a,(3)");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение b,(1)");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите значение c,(0)");
            double c = Convert.ToDouble(Console.ReadLine());
            //Первое действие//
            double res1 = 1.0 + Math.Abs(b - a);
            //Второе действие//
            double res2 = Math.Pow(a, b + 1.0) + Math.Pow(Math.E, b - 1.0) / 1.0 + a * Math.Abs(b - Math.Tan(c));
            //Третье действие//
            double res3 = Math.Abs(Math.Pow(b - a, 2.0));
            double res3_1 = (Math.Abs(Math.Pow(b - a, 2.0)) / 2.0 - (Math.Abs(Math.Pow(b - a, 3.0)) / 3.0));
            //Четвертое действие//
            double res4 = res1 * res2 + res3;
            //Вывод//
            Console.WriteLine("Ответ = {0}", res4);
        }
    }
}