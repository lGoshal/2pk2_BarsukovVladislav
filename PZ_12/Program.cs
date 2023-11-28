using System.Linq;

namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите произвольную строку: ");
            string sent = Console.ReadLine();
            Console.WriteLine("Введите строку для проверки вхождения: ");
            string subsent = Console.ReadLine();
            Console.WriteLine("Строка " + subsent + " входит в строку: " + sent + ", " + StringSearch(subsent, sent) + " раз ");
        }
        static int StringSearch(string subsent, string sent)
        {
            int count = 0;
            string[] str = sent.Split(' ');
                for (int i = 0; i < str.Length; i++) 
            {
                if (subsent.Contains(str[i]))
                    count++;
            }
                return count;
        }
    }
}