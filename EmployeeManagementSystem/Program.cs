using EmployeeManagementSystem;
using System;

EmployeeManager employeeManager = new EmployeeManager();

while (true)
{
  Console.WriteLine("1. Добавить полного сотрудника");
  Console.WriteLine("2. Добавить частичного сотрудника");
  Console.WriteLine("3. Получить информацию о сотруднике");
  Console.WriteLine("4. Обновить данные сотрудника");
  Console.WriteLine("5. Выйти");
  Console.Write("Выберите действие: ");

  var choice = Console.ReadLine();

  switch (choice)
  {
    case "1":
      Console.Write("Введите имя сотрудника: ");
      string fullName = Console.ReadLine();
      Console.Write("Введите фиксированную зарплату: ");
      decimal fullSalary = decimal.Parse(Console.ReadLine());
      employeeManager.Add(new FullTimeEmployee(fullName, fullSalary));
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("Сотрудник добавлен.");
      Console.ResetColor();
      break;

    case "2":
      Console.Write("Введите имя сотрудника: ");
      string partName = Console.ReadLine();
      Console.Write("Введите почасовую ставку: ");
      decimal hourlyRate = decimal.Parse(Console.ReadLine());
      Console.Write("Введите количество отработанных часов: ");
      int hoursWorked = int.Parse(Console.ReadLine());
      employeeManager.Add(new PartTimeEmployee(partName, hourlyRate, hoursWorked));
      Console.ForegroundColor = ConsoleColor.Green;
      Console.Write("Сотрудник добавлен.");
      Console.ResetColor();
      break;

    case "3":
      Console.Write("Введите имя сотрудника для получения информации: ");
      string nameToGet = Console.ReadLine();
      var employee = employeeManager.Get(nameToGet);
      if (employee != null)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Имя: {employee.Name}, Зарплата: {employee.CalculateSalary()}");
        Console.ResetColor();
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Сотрудник не найден.");
        Console.ResetColor();
      }
      break;

    case "4":
      Console.Write("Введите имя сотрудника для обновления данных: ");
      string nameToUpdate = Console.ReadLine();
      var existingEmployee = employeeManager.Get(nameToUpdate);
      if (existingEmployee != null)
      {
        if (existingEmployee is FullTimeEmployee fullTimeEmployee)
        {
          Console.Write("Введите новую фиксированную зарплату: ");
          fullTimeEmployee.BaseSalary = decimal.Parse(Console.ReadLine());
        }
        else if (existingEmployee is PartTimeEmployee partTimeEmployee)
        {
          Console.Write("Введите новую почасовую ставку: ");
          partTimeEmployee.HourlyRate = decimal.Parse(Console.ReadLine());
          Console.Write("Введите новое количество отработанных часов: ");
          partTimeEmployee.HoursWorked = int.Parse(Console.ReadLine());
        }
        employeeManager.Update(existingEmployee);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Данные обновлены.");
        Console.ResetColor();
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Сотрудник не найден.");
        Console.ResetColor();
      }
      break;

    case "5":
      return;

    default:
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Некорректный выбор. Попробуйте снова.");
      Console.ResetColor();
      break;
  }
  Console.WriteLine();
}