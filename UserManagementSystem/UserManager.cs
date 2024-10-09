using System;
using System.Collections.Generic;
using System.IO;
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
    #region Константы

    /// <summary>
    /// Имя файла с пользователями.
    /// </summary>
    private const string filename = "users.txt";

    #endregion

    #region Поля и свойства

    /// <summary>
    /// Пользователи.
    /// </summary>
    private static List<User> users = new();

    #endregion

    #region Методы

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
    private static void LoadFromFile()
    {
      string[] usersFromFile = File.ReadAllLines(filename);
      usersFromFile
        .ToList()
        .ForEach(x =>
        {
          var user = x.Split(" ");
          users.Add(new User(int.Parse(user[0]), user[1], user[2]));
        });
    }

    /// <summary>
    /// Сохранить данные. 
    /// </summary>
    private static void SaveToFile()
    {
      var usersArray = users
        .Select(x => $"{x.Id} {x.Name} {x.Email}");

      File.WriteAllLines(filename, usersArray);
    }

    /// <summary>
    /// Добавить пользователя.
    /// </summary>
    /// <param name="user">Пользователь.</param>
    public void AddUser(User user)
    {
      if (users.Exists(u => u.Id == user.Id))
      {
        throw new UserAlreadyExistsException($"Пользователь с идентификатором {user.Id} уже есть.");
      }
      users.Add(user);
      SaveToFile();
    }

    /// <summary>
    /// Удалить пользователя.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    public void RemoveUser(int id)
    {
      var user = GetUser(id);
      users.Remove(user);
      SaveToFile();
    }

    /// <summary>
    /// Получить пользователя.
    /// </summary>
    /// <param name="id">Идентификатор пользователя.</param>
    /// <returns>Пользователь.</returns>
    public User GetUser(int id)
    {
      var user = users.FirstOrDefault(x => x.Id == id);
      if (user == null)
      {
        throw new UserNotFoundException($"Пользователь с идентификатором {id} не найден.");
      }
      return user;
    }

    /// <summary>
    /// Вывод пользователей на консоль.
    /// </summary>
    public void ListUsers()
    {
      if (users.Count == 0)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Пользователей нет.");
        Console.ResetColor();
        return;
      }
      users.ForEach(x => Console.WriteLine($"{x.Id} - Имя: {x.Name}, Email: {x.Email}"));
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    public UserManager()
    {
      CreateFileIfNotExists();
      LoadFromFile();
    }

    #endregion
  }
}
