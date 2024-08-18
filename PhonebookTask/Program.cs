using PhonebookTask;
using System;
using System.Linq;

var phonebook = Phonebook.GetInstance;

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
            var phoneNumberForAdd = Console.ReadLine();
            if (!phonebook.IsPhoneNumber(phoneNumberForAdd))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер должен состоять из 11 цифр.\n");
                Console.ResetColor();
                break;
            }
            Console.Write("Введите имя: ");
            var nameForAdd = Console.ReadLine();
            if (!phonebook.IsName(nameForAdd))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Имя должно состоять только из букв.\n");
                Console.ResetColor();
                break;
            }
            Abonent abonentForAdd = new Abonent() { Name = nameForAdd, PhoneNumber = phoneNumberForAdd };
            if (phonebook.GetAllAbonents().Any(x => x.PhoneNumber == abonentForAdd.PhoneNumber))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Абонент с таким номером уже существует.\n");
                Console.ResetColor();
            }
            else
            {
                phonebook.AddAbonent(abonentForAdd);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Абонент добавлен.\n");
                Console.ResetColor();
            }
            break;

        case "2":
            Console.Write("Введите номер телефона для удаления: ");
            var phoneNumberForDelete = Console.ReadLine();
            if (!phonebook.IsPhoneNumber(phoneNumberForDelete))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер должен состоять из 11 цифр.\n");
                Console.ResetColor();
                break;
            }
            var abonentForDelete = phonebook.GetAllAbonents().FirstOrDefault(x => x.PhoneNumber == phoneNumberForDelete);
            if (abonentForDelete is not null)
            {
                phonebook.DeleteAbonent(abonentForDelete);
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
            break;

        case "3":
            Console.Write("Введите номер телефона: ");
            var numberToFind = Console.ReadLine();
            if (!phonebook.IsPhoneNumber(numberToFind))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номер должен состоять из 11 цифр.\n");
                Console.ResetColor();
                break;
            }
            Abonent abonentByPhoneNumber = phonebook.GetAbonentByPhoneNumber(numberToFind);
            if (abonentByPhoneNumber is not null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Найденный абонент: {abonentByPhoneNumber.Name} - {abonentByPhoneNumber.PhoneNumber}.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Абонент не найден.\n");
                Console.ResetColor();
            }
            break;

        case "4":
            Console.Write("Введите имя: ");
            var nameToFind = Console.ReadLine();
            if (!phonebook.IsName(nameToFind))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Имя должно состоять только из букв.\n");
                Console.ResetColor();
                break;
            }
            var phoneNumbers = phonebook.GetPhoneNumbersByName(nameToFind);
            if (!phoneNumbers.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Номера не найдены.\n");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Найденные номера: ");
                phoneNumbers.ForEach(x => Console.WriteLine($"{x.Name} - {x.PhoneNumber}"));
                Console.ResetColor();
                Console.WriteLine();
            }
            break;

        case "5":
            var abonents = phonebook.GetAllAbonents();
            if (!abonents.Any())
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