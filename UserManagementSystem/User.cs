
namespace UserManagementSystem
{
  /// <summary>
  /// Пользователь.
  /// </summary>
  public class User
  {
    #region Поля и свойства

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Почтовый адрес.
    /// </summary>
    public string Email { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="name">Имя.</param>
    /// <param name="email">Почтовый адрес.</param>
    public User(int id, string name, string email)
    {
      Id = id;
      Name = name;
      Email = email;
    }

    #endregion
  }
}
