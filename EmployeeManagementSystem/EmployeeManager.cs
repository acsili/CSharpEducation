using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
  /// <summary>
  /// Репозиторий для работы с сотрудниками.
  /// </summary>
  public class EmployeeManager : IEmployeeManager<Employee>
  {
    #region Константы

    /// <summary>
    /// Имя файла с сотрудниками.
    /// </summary>
    private const string filename = "employees.txt";

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Сотрудники.
    /// </summary>
    private readonly Dictionary<string, Employee> employees = new();

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
      string[] employeesFromFile = File.ReadAllLines(filename);
      employeesFromFile
        .ToList()
        .ForEach(x =>
        {
          var employee = x.Split(" ");
          if (employee.Length == 2)
            employees.Add(employee[0], new FullTimeEmployee() 
            { 
              Name = employee[0], 
              BaseSalary = decimal.Parse(employee[1]) 
            });
          else
            employees.Add(employee[0], new PartTimeEmployee() 
            { Name = employee[0], 
              HourlyRate = decimal.Parse(employee[1]), 
              HoursWorked = int.Parse(employee[2])
            });
        });
    }

    /// <summary>
    /// Сохрание данных. 
    /// </summary>
    private void SaveToFile()
    {
      var employeesArray = employees
        .Select(x =>
        {
          if (x.Value is FullTimeEmployee)
          {
            var f = x.Value as FullTimeEmployee;
            return $"{f.Name} {f.BaseSalary}";
          }
          else
          {
            var p = x.Value as PartTimeEmployee;
            return $"{p.Name} {p.HourlyRate} {p.HoursWorked}";
          }
        });
      File.WriteAllLines(filename, employeesArray);
    }

    /// <summary>
    /// Добавить сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    public void Add(Employee employee)
    {
      employees.Add(employee.Name, employee);
      SaveToFile();
    }

    /// <summary>
    /// Получить данные сотрудника.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <returns>Сотрудник.</returns>
    public Employee Get(string name)
    {
      employees.TryGetValue(name, out var employee);
      return employee;
    }

    /// <summary>
    /// Обновить данные сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    public void Update(Employee employee)
    {
      if (employees.ContainsKey(employee.Name))
      {
        employees[employee.Name] = employee;
        SaveToFile();
      }
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public EmployeeManager()
    {
      CreateFileIfNotExists();
      LoadFromFile();
    }

    #endregion
  }
}
