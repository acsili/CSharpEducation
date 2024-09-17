using System;

namespace UserManagementSystem
{
  /// <summary>
  /// Исключение для случая, когда пользователь уже существует.
  /// </summary>
  public class UserAlreadyExistsException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public UserAlreadyExistsException(string message) 
      : base(message) { }
  }
}
