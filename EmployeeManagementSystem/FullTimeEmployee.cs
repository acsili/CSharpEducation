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
    public override string Name { get; set; } = string.Empty;
    public override decimal BaseSalary { get; set; }

    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }

    public FullTimeEmployee() { }

    public FullTimeEmployee(string name, decimal baseSalary)
    {
      Name = name;
      BaseSalary = baseSalary;
    }
  }
}
