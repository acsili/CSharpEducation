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
    public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override decimal BaseSalary { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override decimal CalculateSalary()
    {
      throw new NotImplementedException();
    }
  }
}
