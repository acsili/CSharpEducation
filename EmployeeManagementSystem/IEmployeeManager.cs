using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem
{
  /// <summary>
  /// Интерфейс репозитория для работы с сотрудниками.
  /// </summary>
  /// <typeparam name="T">Общий тип.</typeparam>
  public interface IEmployeeManager<T>
  {
    /// <summary>
    /// Добавить сотрудника.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Add(T employee);

    /// <summary>
    /// Получить струдника.
    /// </summary>
    /// <param name="name">Имя.</param>
    /// <returns>Сотрудник.</returns>
    T Get(string name);

    /// <summary>
    /// Обновить.
    /// </summary>
    /// <param name="employee">Сотрудник.</param>
    void Update(T employee);
  }
}
