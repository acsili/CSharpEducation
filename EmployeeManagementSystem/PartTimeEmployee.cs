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
    public decimal HourlyRate { get; set; }
    public int HoursWorked { get; set; }
    public override string Name { get; set; } = string.Empty;
    public override decimal BaseSalary { get; set; }

    public override decimal CalculateSalary()
    {
      return HourlyRate * HoursWorked; 
    }

    public PartTimeEmployee() { }

    public PartTimeEmployee(string name, decimal hourlyRate, int hoursWorked)
    {
      Name = name;
      HourlyRate = hourlyRate;
      HoursWorked = hoursWorked;
    }
  }
}
