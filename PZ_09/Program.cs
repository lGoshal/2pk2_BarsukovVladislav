namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();//Ввод переменной и присвоение ей значение истина    
            bool isValidIdentifier = true;



            if (string.IsNullOrEmpty(word))//Проверка на нулевую строку
                isValidIdentifier = false;


            char firstChar = word[0]; // Проверка первого символа
            if (!Char.IsLetter(firstChar) && firstChar != '_')
                isValidIdentifier = false;


            for (int i = 1; i < word.Length; i++)// Проверка остальных символов
            {
                char ch = word[i];
                if (!Char.IsLetterOrDigit(ch) && ch != '_')
                    isValidIdentifier = false;
            }


            if (isValidIdentifier)//Вывод результата
                Console.WriteLine("Введенное слово является идентификатором.");
            else
                Console.WriteLine("Введенное слово не является идентификатором.");
        }
    }
}