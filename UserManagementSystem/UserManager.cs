using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementSystem
{
  /// <summary>
  /// Репозиторий для работы с пользователями.
  /// </summary>
  public class UserManager
  {
    #region Поля и свойства

    /// <summary>
    /// Пользователи.
    /// </summary>
    public List<User> Users = new();

    #endregion

    #region Методы

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="user"></param>
    public void AddUser(User user)
    {
      Users.Add(user);
    }

    /// <summary>
    /// Удалить пользователя.
    /// </summary>
    /// <param name="id"></param>
    public void RemoveUser(int id)
    {
      Users.RemoveAt(id);
    }

    /// <summary>
    /// Получить пользователя.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public User GetUser(int id)
    {
      return Users.FirstOrDefault(x => x.Id == id);
    }

    /// <summary>
    /// Вывод пользователей на консоль.
    /// </summary>
    public void ListUsers()
    {
      if (Users.Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Пользователей нет.");
        Console.ResetColor();
        return;
      }
      Users.ForEach(x => Console.WriteLine($"Имя: {x.Name}, Email: {x.Email}"));
    }

    #endregion
  }
}
