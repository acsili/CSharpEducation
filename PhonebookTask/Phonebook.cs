using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhonebookTask
{
    /// <summary>
    /// Телефонная книга.
    /// </summary>
    internal class Phonebook
    {
        #region Константы

        /// <summary>
        /// Путь к файлу с абонентами.
        /// </summary>
        private const string filename = "phonebook.txt";

        #endregion

        #region Поля и свойства

        /// <summary>
        /// Абоненты.
        /// </summary>
        private List<Abonent> abonents = new List<Abonent>();

        /// <summary>
        /// Хранение единственного экземпляра.
        /// </summary>
        private static Phonebook? instance;

        /// <summary>
        /// Получение экземпляра.
        /// </summary>
        /// <returns>Объект типа Phonebook</returns>
        public static Phonebook Instance => instance ?? new Phonebook();

        #endregion

        #region Методы

        /// <summary>
        /// Создать файл.
        /// </summary>
        private static void CreateFileIfNotExists()
        {
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
            }
        }

        /// <summary>
        /// Загрузить данные из файла.
        /// </summary>
        private void LoadFromFile()
        {
            string[] abonentsFromFile = File.ReadAllLines(filename);
            abonentsFromFile
                .ToList()
                .ForEach(x => abonents.Add(new Abonent() { Name = x.Split(" - ")[0], PhoneNumber = x.Split(" - ")[1] }));
        }

        /// <summary>
        /// Сохрание данных. 
        /// </summary>
        private void SaveToFile()
        {
            var abonentsArray = abonents.Select(x => $"{x.Name} - {x.PhoneNumber}");
            File.WriteAllLines(filename, abonentsArray);
        }

        /// <summary>
        /// Добавление абонента.
        /// </summary>
        /// <param name="abonent">Абонент.</param>
        public void AddAbonent(Abonent abonent)
        {
            abonents.Add(abonent);
            SaveToFile();
        }

        /// <summary>
        /// Удаление абонента.
        /// </summary>
        /// <param name="abonent">Абонент.</param>
        public void DeleteAbonent(Abonent abonent)
        {
            abonents.Remove(abonent);
            SaveToFile();
        }

        /// <summary>
        /// Получение всех абонентов.
        /// </summary>
        /// <returns>Абоненты.</returns>
        public List<Abonent> GetAllAbonents()
        {
            return abonents;
        }

        /// <summary>
        /// Получение абонента по номеру телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <returns>Абонент.</returns>
        public Abonent GetAbonentByPhoneNumber(string phoneNumber)
        {
            return abonents.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
        }

        /// <summary>
        /// Получение номеров по имени абонента.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        /// <returns>Абоненты.</returns>
        public List<Abonent> GetPhoneNumbersByName(string name)
        {
            return abonents.Where(x => x.Name == name).ToList();
        }

        /// <summary>
        /// Проверка ввода номера телефона.
        /// </summary>
        /// <param name="phoneNumber">Номер телефона.</param>
        /// <returns>Если ввод корректный - true, иначе false.</returns>
        public bool CheckIsPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 11)
            {
                return false;
            }

            foreach (char p in phoneNumber)
            {
                if (!char.IsDigit(p))
                {
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
        public bool CheckIsName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false; 
                }
            }

            return true;
        }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создание файла. Загрузка данных из файла.
        /// </summary>
        private Phonebook()
        {
            CreateFileIfNotExists();
            LoadFromFile();
        }

        #endregion
    }
}

