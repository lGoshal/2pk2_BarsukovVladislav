namespace PZ_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sent = ("Hello, World! My name is gosha rubchinskiy. I`m study in kolledg OKEI.");//Произвольная строка
            string[] sent1 = sent.Split('.', '!', '?');//Создание массива из строки с разделением по предложениям
            Array.Sort(sent1, (x, y) => y.Length.CompareTo(x.Length));//Сортировка массива при помози присвоения предложениям переменных x и y, и сравнение их между собой по длинне от большего к меньшему
            for (int i = 0; i < sent1.Length; i++) { Console.WriteLine(sent1[i]); }//Вывод массива
        }
    }
}