namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random ran = new Random();
            int height = 8;
            int[][] arr = new int[height][];
            Random rnd = new Random();

            // Первое задание

            for (int i = 0; i < height; i++)
            {
                int length = rnd.Next(6, 11);
                arr[i] = new int[length];
                for (int j = 0; j < length; j++)
                {
                    arr[i][j] = rnd.Next(6, 11);
                }
            }

            // Второе задание

            Console.WriteLine("Номер 2");
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Третье задание

            Console.WriteLine("Номер 3");
            double[] newArr = new double[8];
            for (int i = 0; i < 8; i++)
            {
                newArr[i] = arr[i][arr[i].Length - 1];
            }
            Console.WriteLine("Последние элементы зубчатого массива: ");
            foreach (double v in newArr)
            {
                Console.Write(v + " ");
            }
            Console.WriteLine();


            // Четвертое задание

            Console.WriteLine("Номер 4");
            int[][] copyArr = arr;
            for (int i = 0; i < 8; i++)
            {
                Array.Sort(copyArr[i]);
            }
            Console.WriteLine("Максимальные значения каждой строки массива: ");
            for (int i = 0; i < 8; i++)
            {
                newArr[i] = copyArr[i][copyArr[i].Length - 1];
                Console.Write(newArr[i] + " ");
            }
            Console.WriteLine();

            // Пятое задание
           
            Console.WriteLine("Номер 5 ");
            int forFirst = 0;
            int forMax = 0;
            int[] maxElements = new int[8];
            int[] FirstNum = new int[8];
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    if (arr[i][j] == FirstNum[forFirst])
                    {
                        arr[i][j] = maxElements[forFirst];

                    }
                    else if (arr[i][j] == maxElements[forMax])
                    {
                        arr[i][j] = FirstNum[forMax];
                    }
                    Console.Write(arr[i][j] + " ");
                }
                forFirst++;
                forMax++;
                Console.WriteLine();
            }

            //Шестое задание

            Console.WriteLine("Номер 6");
            for (int i = 0; i < arr.Length; i++)
            {
                Array.Reverse(arr[i]);
            }
           
            // Выводим реверсированный зубчатый массив
           
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            //Седьмое задание

            Console.WriteLine("Номер 7");
            double sr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    sr += arr[i][j];

                }
                sr /= arr[i].Length;
                Console.WriteLine(sr);
                sr = 0;
            }
        }
    }
}