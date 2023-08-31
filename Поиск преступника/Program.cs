using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Поиск_преступника
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GangstersFactory gangstersFactory = new GangstersFactory();
            Detective detective = new Detective(gangstersFactory.Create());

            detective.Work();
        }
    }

    class Gangster
    {
        public Gangster(string name, int height, int width, string nationality, bool isInPricon)
        {
            Name = name;
            Height = height;
            Width = width;
            Nationality = nationality;
            IsInPrison = isInPricon;
        }

        public string Name { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string Nationality { get; private set; }
        public bool IsInPrison { get; private set; }
    }

    class GangstersFactory
    {
        public List<Gangster> Create()
        {
            List<Gangster> gangsters = new List<Gangster>()
            {
                new Gangster("Конор", 172, 72, "Ирландец", true),
                new Gangster("Арнольд", 185, 95, "Австриец", false),
                new Gangster("Гиворг", 172, 72, "Грузин", false),
                new Gangster("Стивен", 172, 72, "Американец", true),
                new Gangster("Туко", 172, 72, "Мексиканец", true),
                new Gangster("Рашид", 172, 72, "Дпгестанец", false),
                new Gangster("Дмитрий", 172, 72, "Русский", true)
            };

            return gangsters;
        }
    }

    class Detective
    {
        private List<Gangster> _gangsters;

        public Detective(List<Gangster> gangters)
        {
            _gangsters = gangters;
        }

        public void Work()
        {
            const string CommandShowAllGangsters = "1";
            const string CommandFindGangsters = "2";
            const string CommandCompleteProgramm = "Exit";

            bool isWork = true;

            while (true)
            {
                Console.WriteLine($"{CommandShowAllGangsters} - Весь список преступников");
                Console.WriteLine($"{CommandFindGangsters} - Поиск преступника");
                Console.WriteLine($"{CommandCompleteProgramm} - Завершить программу");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowAllGangsters:
                        ShowAllGangsters();
                        break;

                    case CommandFindGangsters:
                        FindGangter();
                        break;

                    case CommandCompleteProgramm:
                        Console.WriteLine("Программа завершена");
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void FindGangter()
        {
            Console.WriteLine("Введите Рост преступника");
            int introducedHeight = ReadInt();

            Console.WriteLine("Введите Вес преступника");
            int introducedWidth = ReadInt();

            Console.WriteLine("Введите национальность прееступника");
            string introdusedNationality = Console.ReadLine();

            var searchGangster = _gangsters.Where(gangster => introducedHeight == gangster.Height &&
                                                              introducedWidth == gangster.Width &&
                                                              introdusedNationality == gangster.Nationality &&
                                                              gangster.IsInPrison == false);

            if(searchGangster.Count() == 0 ) 
            {
                Console.WriteLine("Преступник не найден или сидит в тюрьме");

                return;
            }

            foreach ( Gangster gangster in searchGangster)
            {
                Console.WriteLine(gangster.Name);
            }
        }

        private void ShowAllGangsters()
        {
            foreach (Gangster gangter in _gangsters)
            {
                Console.WriteLine($"Имя: {gangter.Name}, Рост: {gangter.Height}, Вес: " +
                                  $"{gangter.Width}, Национальность: {gangter.Nationality}, " +
                                  $"В тюрьме?: {gangter.IsInPrison}");
            }
        }

        private static int ReadInt()
        {
            int number = 0;

            bool result = false;

            while (result == false)
            {
                result = int.TryParse(Console.ReadLine(), out number);

                if (result == false)
                {
                    Console.WriteLine("Ошибка. Введите число.");
                }
            }

            return number;
        }
    }
}
