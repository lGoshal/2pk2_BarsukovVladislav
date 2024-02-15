using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_18
{
    public class Abonent
    {
        //Тарифы
        public enum Tariff
        {
            Maxi,
            Standard,
            Economy
        }

        //Проверка на пустую строку и ввод имени
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("ФИО не может быть пустым. Повторите ввод:");
                    _fullName = Console.ReadLine();
                }
                else
                {
                    _fullName = value;
                }
            }
        }

        //Свойство тирифов
        public Tariff AbonentTariff { get; set; }

        //Свойства тарифа минуты
        public int Minutes
        {
            get
            {
                switch (AbonentTariff)
                {
                    case Tariff.Maxi:
                        return 1000;
                    case Tariff.Standard:
                        return 500;
                    case Tariff.Economy:
                        return 300;
                    default:
                        return 0;
                }
            }
        }

        //Свойства тарифа интернет
        public int InternetGb
        {
            get
            {
                switch (AbonentTariff)
                {
                    case Tariff.Maxi:
                        return 50;
                    case Tariff.Standard:
                        return 30;
                    case Tariff.Economy:
                        return 10;
                    default:
                        return 0;
                }
            }
        }

        //Количество абонентов на тарифах
        public static int MaxiAbonentsCount { get; set; }
        public static int StandardAbonentsCount { get; set; }
        public static int EconomyAbonentsCount { get; set; }

        //Счетчки абонентов на том или ином тарифе
        public Abonent(string fullName, Tariff abonentTariff)
        {
            FullName = fullName;
            AbonentTariff = abonentTariff;

            switch (AbonentTariff)
            {
                case Tariff.Maxi:
                    MaxiAbonentsCount++;
                    break;
                case Tariff.Standard:
                    StandardAbonentsCount++;
                    break;
                case Tariff.Economy:
                    EconomyAbonentsCount++;
                    break;
            }
        }

        //Метод иммитирующий звонок
        public void MakeCall(int callDuration)
        {
            Console.WriteLine($"Абонент {FullName} совершил звонок продолжительностью {callDuration} мин, остаток минут: {Minutes - callDuration}");
        }

        //Метод иммитирующий передачу данных
        public void SendData(double dataVolumeMB)
        {
            Console.WriteLine($"Абонент {FullName} передал информацию в объеме {dataVolumeMB} Мб, остаток тарифа: {InternetGb - (dataVolumeMB / 1000.0)} Гб");
        }

        //Статичные строки
        public static void DisplayAbonentsCount()
        {
            Console.WriteLine($"Количество абонентов на тарифе Макси: {MaxiAbonentsCount}");
            Console.WriteLine($"Количество абонентов на тарифе Стандарт: {StandardAbonentsCount}");
            Console.WriteLine($"Количество абонентов на тарифе Эконом: {EconomyAbonentsCount}");
        }
    }
}
