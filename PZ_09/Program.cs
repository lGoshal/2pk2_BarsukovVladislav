using System.Net.Http.Headers;

namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст:");
            string inputText = Console.ReadLine();

            string[] words = inputText.Split(' ');

            Console.WriteLine("Анализ введенного текста:");
            foreach (string word in words)
            {
                if (IsNumber(word)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (word.Length > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.Write($"{word} ");
            }

            Console.ResetColor();
            Console.WriteLine();
        }

        static bool IsNumber(string word)
        {
            int number;
            return int.TryParse(word, out number);
        }
    }
}