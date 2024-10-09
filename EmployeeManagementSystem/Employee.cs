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
    #region Поля и свойства

    /// <summary>
    /// Имя.
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Базовая зарплата.
    /// </summary>
    public abstract decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Вычислить зарплату сотрудника.
    /// </summary>
    /// <returns>Зарплата сотрудника.</returns>
    public abstract decimal CalculateSalary();

    #endregion
  }
}
