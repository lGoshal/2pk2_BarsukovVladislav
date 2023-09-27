namespace PZ_06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание массива и введение рандома
            int[] a = new int[12];
            Random random = new Random();

            // Заполнение массива случайными числами в интервале [-12..12]
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(-12, 13);
            }

            // Вывод исходного массива
            Console.WriteLine("Исходный массив:");
            PrintArray(a);

            // Циклический сдвиг ВПРАВО на 4 элемента
            for (int i = 0; i < 4; i++)
            {
                int lastElement = a[a.Length - 1];

                for (int j = a.Length - 1; j > 0; j--)
                {
                    a[j] = a[j - 1];
                }

                a[0] = lastElement;
            }

            // Вывод результирующего массива
            Console.WriteLine("Результирующий массив после циклического сдвига вправо на 4 элемента:");
            PrintArray(a);
        }

       //Вывод массива
        static void PrintArray(int[] a)
        {
            foreach (int element in a)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}