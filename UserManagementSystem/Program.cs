using System;
using UserManagementSystem;

UserManager userManager = new UserManager();

while (true)
{
  Console.WriteLine("1. Добавить пользователя");
  Console.WriteLine("2. Удалить пользователя");
  Console.WriteLine("3. Список пользователей");
  Console.WriteLine("4. Выход");
  Console.Write("Выберите действие: ");

  string choice = Console.ReadLine();

  try
  {
    switch (choice)
    {
      case "1":
        Console.Write("Введите Id: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите Email: ");
        string email = Console.ReadLine();
        userManager.AddUser(new User(id, name, email));
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Пользователь добавлен.");
        Console.ResetColor();
        break;

      case "2":
        Console.Write("Введите Id: ");
        int removeId = int.Parse(Console.ReadLine());
        userManager.RemoveUser(removeId);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Пользователь удален.");
        Console.ResetColor();
        break;

      case "3":
        userManager.ListUsers();
        break;

      case "4":
        return;

      default:
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Некорректный выбор. Попробуйте снова.");
        Console.ResetColor();
        break;
    }
  }
  catch (FormatException)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Неверный формат ввода. Введите число.");
    Console.ResetColor();
  }
  catch (UserAlreadyExistsException ex)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
  }
  catch (UserNotFoundException ex)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
  }
  catch (Exception ex)
  {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Ошибка: {ex.Message}");
    Console.ResetColor();
  }
  Console.WriteLine();
}