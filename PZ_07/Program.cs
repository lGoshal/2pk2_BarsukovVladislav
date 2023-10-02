namespace PZ_07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] B = new int[7, 7];
            Random random = new Random();

            // Заполняем массив случайными числами в диапазоне [-10..10]
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    B[i, j] = random.Next(-10, 11);
                }
            }

            // Выводим главную диагональ и считаем количество положительных элементов
            int a = 0;
            for (int i = 0; i < 7; i++)
            {
                Console.Write(B[i, i] + " ");
                if (B[i, i] > 0)
                {
                    a++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество положительных элементов на главной диагонали: " + a);
        }
    }

}