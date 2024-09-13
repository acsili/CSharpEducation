using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
  public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
  {
    #region Константы

    /// <summary>
    /// Имя файла с сотрудниками.
    /// </summary>
    private const string filename = "employees.txt";

    #endregion

    private readonly List<Employee> employees = new();

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
            employees.Add(new FullTimeEmployee() { Name = employee[0], BaseSalary = decimal.Parse(employee[1]) });
          else
            employees.Add(new PartTimeEmployee() { Name = employee[0], HourlyRate = decimal.Parse(employee[1]), HoursWorked = int.Parse(employee[2])});
        });
    }

    /// <summary>
    /// Сохрание данных. 
    /// </summary>
    private void SaveToFile()
    {
      var abonentsArray = employees
        .Select(x =>
        {
          if (x is FullTimeEmployee)
          {
            var f = x as FullTimeEmployee;
            return $"{f.Name} {f.BaseSalary}";
          }
          else
          {
            var p = x as PartTimeEmployee;
            return $"{p.Name} {p.HourlyRate} {p.HoursWorked}";
          }
        });
      File.WriteAllLines(filename, abonentsArray);
    }

    public EmployeeManager() 
    {
      CreateFileIfNotExists();
      LoadFromFile();
    }

    public void Add(T employee)
    {
      employees.Add(employee);
      SaveToFile();
    }

    public T Get(string name)
    {

      throw new NotImplementedException();
    }

    public void Update(T employee)
    {
      throw new NotImplementedException();
    }


  }
}
