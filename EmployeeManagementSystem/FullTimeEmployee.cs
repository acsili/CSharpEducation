using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
  /// <summary>
  /// Полный сотрудник.
  /// </summary>
  public class FullTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Имя.
    /// </summary>
    public override string Name { get; set; } = string.Empty;

    /// <summary>
    /// Зарплата.
    /// </summary>
    public override decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Вычислить зарплату.
    /// </summary>
    /// <returns>Зарплата.</returns>
    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public FullTimeEmployee() { }

    /// <summary>
    /// Конструктор с параметрами. 
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="baseSalary">Зарплата.</param>
    public FullTimeEmployee(string name, decimal baseSalary)
    {
      Name = name;
      BaseSalary = baseSalary;
    }

    #endregion
  }
}
