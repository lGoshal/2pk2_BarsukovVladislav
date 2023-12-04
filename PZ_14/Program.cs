namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] A = new int[5, 8];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    A[i, j] = i * j;
                }
            }

            FileStream file = new FileStream(@"D:\test.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(file); 
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        writer.Write(A[i, j] + " ");
                    }
                    writer.WriteLine();
                }
            }
            writer.Close();
            Console.WriteLine("Массив успешно записан в файл: test.txt");
        }
    }
}