using System;

namespace UserManagementSystem
{
  /// <summary>
  /// Исключение для случая, когда пользователь не найден.
  /// </summary>
  public class UserNotFoundException : Exception
  {
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение.</param>
    public UserNotFoundException(string message) 
      : base(message) { }
  }
}
