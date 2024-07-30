using System;

namespace TicTacToe
{
    /// <summary>
    /// Игра "Крестики-нолики"
    /// </summary>
    internal class TicTacToeGame
    {

        #region Constants

        /// <summary>
        /// Обозначение крестика.
        /// </summary>
        private const char symbolX = 'X';

        /// <summary>
        /// Обозначение нолика.
        /// </summary>
        private const char symbolO = 'O';

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Доска.
        /// </summary>
        private static char[] board;

        /// <summary>
        /// Текущий игрок.
        /// </summary>
        private static char currentPlayer;

        /// <summary>
        /// Игрок против компьютера.
        /// </summary>
        private static bool isPlayingAgainstComputer;
        
        #endregion

        #region Methods

        /// <summary>
        /// Запуск игры.
        /// </summary>
        public static void StartGame()
        {
            InternalStartGame();
            while (true)
            {
                DrawBoard();
                Console.WriteLine();

                bool isInputValid;
                int choice;

                do
                {
                    Console.Write($"Ход {currentPlayer}: ");

                    if (isPlayingAgainstComputer && currentPlayer == symbolO)
                    {
                        choice = ComputerMove();
                        board[choice - 1] = currentPlayer;
                        Console.WriteLine(choice);
                        break;
                    }

                    isInputValid = int.TryParse(Console.ReadLine(), out choice) && 
                                    choice >= 1 && choice <= 9 &&
                                    board[choice - 1] != symbolX && 
                                    board[choice - 1] != symbolO;

                    if (isInputValid)
                    {
                        board[choice - 1] = currentPlayer;
                    }
                    else
                    {
                        Console.WriteLine("Неверный ход!\n");
                    }
                    
                } while (!isInputValid);

                if (CheckIsWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine($"Игрок {currentPlayer} победил!");
                    StickmanAnimation.PlayAnimation(currentPlayer);
                    InternalStartGame();
                }

                if (CheckIsDraw())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    InternalStartGame();
                }

                currentPlayer = (currentPlayer == symbolX) ? symbolO : symbolX;
            }
        }

        /// <summary>
        /// Отрисовка игрового поля.
        /// </summary>
        private static void DrawBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < board.Length; i++)
            {
                Console.Write("| ");
                if (board[i] == symbolX)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(board[i]);
                }
                else if (board[i] == symbolO)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(board[i]);
                }
                else
                {
                    Console.Write(board[i]);
                }
                Console.ResetColor();
                Console.Write(' ');
                if ((i + 1) % 3 == 0)
                {
                    Console.Write("|");
                    Console.WriteLine();
                    Console.WriteLine("-------------");
                }

            }
        }

        /// <summary>
        /// Проверка на победу игрока. 
        /// </summary>
        /// <returns>true - если один из игроков выиграл, иначе false.</returns>
        private static bool CheckIsWin()
        {
            return (board[0] == board[1] && board[1] == board[2]) || (board[3] == board[4] && board[4] == board[5]) ||
                   (board[6] == board[7] && board[7] == board[8]) || (board[0] == board[3] && board[3] == board[6]) ||
                   (board[1] == board[4] && board[4] == board[7]) || (board[2] == board[5] && board[5] == board[8]) ||
                   (board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]);
        }

        /// <summary>
        /// Проверка на ничью.
        /// </summary>
        /// <returns>true - если ничья, иначе false.</returns>
        private static bool CheckIsDraw()
        {
            foreach (var cell in board)
            {
                if (cell != symbolX && cell != symbolO)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Начать игру.
        /// </summary>
        private static void InternalStartGame()
        {
            string newGame;
            do
            {
                Console.Write("Новая игра? [y/n] ");
                newGame = Console.ReadLine()!;
                if (newGame == "y")
                {
                    board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    currentPlayer = symbolX;
                    isPlayingAgainstComputer = GetIsPlayingAgainstComputer();
                    Console.Clear();
                    break;
                }
                else if (newGame == "n")
                {
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                }
            } while (true);
        }

        /// <summary>
        /// Определение, хочет ли пользователь сыграть против компьютера.
        /// </summary>
        /// <returns>false — если пользователь выбрал играть против другого игрока, true — если пользователь выбрал играть против компьютера.</returns>
        private static bool GetIsPlayingAgainstComputer()
        {
            string play;
            do
            {
                Console.Write("Хотите сыграть против другого игрока? [y/n] ");
                play = Console.ReadLine()!;
                if (play == "y")
                {
                    return false;
                }
                else if (play == "n")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                }
            } while (true);
        }

        /// <summary>
        /// Ход компьютера.
        /// </summary>
        /// <returns>Когда находится свободная позиция, возвращается значение от 1 до 9</returns>
        private static int ComputerMove()
        {
            Random rand = new Random();
            int move;
            do
            {
                move = rand.Next(0, 9);
            } while (board[move] == symbolX || board[move] == symbolO);
            return move + 1;
        }

        #endregion
    }
}
