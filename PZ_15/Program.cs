namespace PZ_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название директории: ");
            string dirName = Console.ReadLine();
            if (Directory.Exists(dirName))//Проверка на существование директории
            {
                Console.WriteLine("Подкаталоги: ");
                string[] dirs = Directory.GetDirectories(dirName);//Вывод всех папок в директории
                if (dirs.Length == 0)
                    Console.WriteLine("Каталогов нет");
                foreach (string s in dirs)//Вывод папок
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("Файлы: ");//Вывод файлов
            string[] files = Directory.GetFiles(dirName);
            if (files.Length == 0)
            {
                Console.WriteLine("Файлов нет: ");
            }
            else
            {
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine("Укажите название файла: ");//Ввод названия папки
                string FileName = Console.ReadLine();
                FileStream file1 = new FileStream($@"{FileName}.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file1);
                Console.WriteLine(reader.ReadToEnd());
                reader.Close();
            }
        }
    }
}