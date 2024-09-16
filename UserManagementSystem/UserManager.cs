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

    public void AddUser(User user)
    {

    }

    public void RemoveUser(int id)
    {

    }

    public User GetUser(int id)
    {
      return Users.FirstOrDefault(x => x.Id == id);
    }



    #endregion
  }
}
