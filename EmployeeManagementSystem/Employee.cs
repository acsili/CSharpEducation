using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
  /// <summary>
  /// Сотрудник.
  /// </summary>
  public abstract class Employee
  {
    /// <summary>
    /// Имя.
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Зарплата.
    /// </summary>
    public abstract decimal BaseSalary { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public abstract decimal CalculateSalary();
  }
}
