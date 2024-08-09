using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PhonebookTask
{
    /// <summary>
    /// Телефонная книга.
    /// </summary>
    internal class Phonebook
    {

        #region Constants

        /// <summary>
        /// Путь к файлу phonebook.txt.
        /// </summary>
        private const string filePath = "phonebook.txt";

        #endregion


        #region Fields and Properties

        /// <summary>
        /// Абоненты.
        /// </summary>
        private List<Abonent> abonents = new List<Abonent>();

        /// <summary>
        /// Хранение единственного экземпляра.
        /// </summary>
        private static Phonebook? instance;

        #endregion


        #region Constructors

        private Phonebook()
        {
            CreateFile();
            LoadFromFile();
        }

        #endregion


        #region Methods

        /// <summary>
        /// Получение экземпляра.
        /// </summary>
        /// <returns>Объект типа Phonebook</returns>
        public static Phonebook GetInstance()
        {
            instance ??= new Phonebook();
            return instance;
        }

        /// <summary>
        /// Создание файла.
        /// </summary>
        private static void CreateFile()
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        /// <summary>
        /// Загрузка данных из файла.
        /// </summary>
        private void LoadFromFile()
        {
            var abonentsFromFile = File.ReadAllLines(filePath);
            abonentsFromFile.ToList().ForEach(x => abonents.Add(new Abonent() { Name = x.Split(" - ")[0], PhoneNumber = x.Split(" - ")[1] }));
        }

        /// <summary>
        /// Сохрание данных. 
        /// </summary>
        private void SaveToFile()
        {
            var abonentsArray = abonents.Select(x => $"{x.Name} - {x.PhoneNumber}");
            File.WriteAllLines(filePath, abonentsArray);
        }

        /// <summary>
        /// Добавление абонента.
        /// </summary>
        /// <param name="abonent">Абонент.</param>
        private void CreateAbonent(Abonent abonent)
        {
            if (!IsName(abonent.Name))
                return;
            if (!IsPhoneNumber(abonent.PhoneNumber))
                return;

            if (abonents.Any(x => x.PhoneNumber == abonent.PhoneNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Абонент с таким номером уже существует.\n");
                Console.ResetColor();
                return;
            }

            abonents.Add(abonent);
            SaveToFile();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Абонент добавлен.\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Удаление абонента.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        private void DeleteAbonent(string phoneNumber)
        {
            if (!IsPhoneNumber(phoneNumber))
                return;
            var abonent = abonents.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            if (abonent is not null)
            {
                abonents.Remove(abonent);
                SaveToFile();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Абонент удален.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Абонент не найден.\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Получение всех абонентов.
        /// </summary>
        private void GetAllAbonents()
        {
            if (abonents.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номеров нет.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                abonents.ForEach(x => Console.WriteLine($"{x.Name} - {x.PhoneNumber}"));
                Console.ResetColor();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Получение абонента по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        private void GetAbonentByPhoneNumber(string phoneNumber)
        {
            if (IsPhoneNumber(phoneNumber))
            {
                var abonent = abonents.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
                if (abonent is not null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Найденный абонент: {abonent.Name} - {abonent.PhoneNumber}.\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Абонент не найден.\n");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Получение номеров по имени абонента.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        private void GetPhoneNumbersByName(string name)
        {
            if (IsName(name))
            {
                var phoneNumbers = abonents.FirstOrDefault(x => x.Name == name);
                if (phoneNumbers is not null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Найденные номера: ");
                    abonents.Where(x => x.Name == name).ToList().ForEach(x => Console.WriteLine($"{x.Name} - {x.PhoneNumber}"));
                    Console.ResetColor();
                    Console.WriteLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Номера не найдены.\n");
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Проверка ввода номера телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <returns>Если ввод корректный - true, иначе false.</returns>
        private static bool IsPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер не введен.\n");
                Console.ResetColor();
                return false;
            }

            if (phoneNumber.Length != 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер должен именть 11 цифр.\n");
                Console.ResetColor();
                return false;
            }

            foreach (char p in phoneNumber)
            {
                if (!char.IsDigit(p))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Номер должен состоять только из цифр.\n");
                    Console.ResetColor();
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверка ввода имени.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        /// <returns>Если ввод корректный - true, иначе false.</returns>
        private static bool IsName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Имя не введено.\n");
                Console.ResetColor();
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Имя должно состоять только из букв.\n");
                    Console.ResetColor();
                    return false; 
                }
            }

            return true;
        }
        
        /// <summary>
        /// Запуск программы.
        /// </summary>
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Добавить абонента");
                Console.WriteLine("2. Удалить абонента");
                Console.WriteLine("3. Получить абонента по номеру телефона");
                Console.WriteLine("4. Получить номера телефонов по имени");
                Console.WriteLine("5. Показать всех абонентов");
                Console.WriteLine("0. Выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите номер телефона: ");
                        var phoneNumber = Console.ReadLine();
                        Console.Write("Введите имя: ");
                        var name = Console.ReadLine();
                        CreateAbonent(new Abonent() { Name = name, PhoneNumber = phoneNumber});
                        break;

                    case "2":
                        Console.Write("Введите номер телефона для удаления: ");
                        var number = Console.ReadLine();
                        DeleteAbonent(number);
                        break;

                    case "3":
                        Console.Write("Введите номер телефона: ");
                        var numberToFind = Console.ReadLine();
                        GetAbonentByPhoneNumber(numberToFind);                        
                        break;

                    case "4":
                        Console.Write("Введите имя: ");
                        var nameToFind = Console.ReadLine();
                        GetPhoneNumbersByName(nameToFind);
                        break;

                    case "5":
                        GetAllAbonents();
                        break;

                    case "0":
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                        Console.ResetColor();
                        break;
                }
                
            }
        }

        #endregion

    }
}

