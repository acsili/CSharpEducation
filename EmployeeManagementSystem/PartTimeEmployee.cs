using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
  /// <summary>
  /// Частичный сотрудник.
  /// </summary>
  public class PartTimeEmployee : Employee
  {
    #region Поля и свойства

    /// <summary>
    /// Почасовая ставка.
    /// </summary>
    public decimal HourlyRate { get; set; }

    /// <summary>
    /// Количество отработанных часов.
    /// </summary>
    public int HoursWorked { get; set; }

    #endregion

    #region Базовый класс

    #region Поля и свойства

    /// <summary>
    /// Имя.
    /// </summary>
    public override string Name { get; set; } = string.Empty;

    /// <summary>
    /// Базовая зарплата.
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
      return HourlyRate * HoursWorked; 
    }

    #endregion

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public PartTimeEmployee() { }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <param name="hourlyRate">Почасовая ставка.</param>
    /// <param name="hoursWorked">Количество отработанных часов.</param>
    public PartTimeEmployee(string name, decimal hourlyRate, int hoursWorked)
    {
      Name = name;
      HourlyRate = hourlyRate;
      HoursWorked = hoursWorked;
    }

    #endregion
  }
}
