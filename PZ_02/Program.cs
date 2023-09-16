namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите время года \n Зима  - 1 \n Весна - 2 \n Лето  - 3  \n Осень - 4");
            int month = Convert.ToInt32(Console.ReadLine());
            switch (month)
            {
                case 1:
                    Console.WriteLine(" Декабрь - 31 день, \n Январь  - 31 день, \n Февраль  - 28 дней.");
                    break;
                case 2:
                    Console.WriteLine(" Март   - 31 день, \n Апрель - 30 дней, \n Май    - 31 день.");
                    break;
                case 3:
                    Console.WriteLine(" Июнь   - 30 дней, \n Июль   - 31 день, \n Август - 31 день.");
                    break;
                case 4:
                    Console.WriteLine(" Сентябрь - 30 дней, \n Октябрь  - 31 день, \n Ноябрь   - 30 дней.");
                    break;
                default:
                    Console.WriteLine(" Вы ввели не правильное число");
                    break;
            }

        } 
    }
}