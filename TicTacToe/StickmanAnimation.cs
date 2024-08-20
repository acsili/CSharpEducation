using System;
using System.Threading;

namespace TicTacToe
{
    /// <summary>
    /// Управление анимацией человечка.
    /// </summary>
    public class StickmanAnimation
    {
        #region Methods

        /// <summary>
        /// Анимация человечка после победы определенного игрока.
        /// </summary>
        /// <param name="currentPlayer">Победивший игрок.</param>
        public static void PlayAnimation(char currentPlayer)
        {
            Console.CursorVisible = false;
            int groundLevel = Console.WindowHeight - 20;

            for (int i = 0; i < 5; i++)
            {
                DrawNothing(groundLevel - 2);
                DrawStickman(groundLevel, currentPlayer);
                Thread.Sleep(500);

                DrawNothing(groundLevel);
                DrawStickmanJump(groundLevel - 2, currentPlayer);
                Thread.Sleep(300);
            }
        }

        /// <summary>
        /// Человечек стоит.
        /// </summary>
        /// <param name="position">Положение человечка на консоли.</param>
        /// <param name="currentPlayer">Победивший игрок.</param>
        private static void DrawStickman(int position, char currentPlayer)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine($" {currentPlayer} ");
            Console.WriteLine("/|\\");
            Console.WriteLine("/ \\");
        }

        /// <summary>
        /// Человечек прыгнул. 
        /// </summary>
        /// <param name="position">Положение человечка на консоли.</param>
        /// <param name="currentPlayer">Победивший игрок.</param>
        private static void DrawStickmanJump(int position, char currentPlayer)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine($"\\{currentPlayer}/");
            Console.WriteLine(" |");
            Console.WriteLine("/ \\");
        }

        /// <summary>
        /// Стереть человечка с консоли.
        /// </summary>
        /// <param name="position">Положение человечка на консоли.</param>
        private static void DrawNothing(int position)
        {
            Console.SetCursorPosition(0, position);
            Console.WriteLine("   ");
            Console.WriteLine("   ");
            Console.WriteLine("   ");
        }

        #endregion
    }
}
