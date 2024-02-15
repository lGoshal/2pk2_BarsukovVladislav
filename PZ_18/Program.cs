namespace PZ_18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создание абонентов с ФИО и тарифом Maxi/Standart/Economy
            Abonent abonent1 = new Abonent("Иванов Иван Иванович", Abonent.Tariff.Maxi);
            Abonent abonent2 = new Abonent("Петров Петр Петрович", Abonent.Tariff.Standard);

            //Вывод всей информации о абоненте
            Abonent.DisplayAbonentsCount();

            //Методы совершения передачи информации и совершения звонка
            abonent1.MakeCall(100);
            abonent2.SendData(20);
        }
    }
}
