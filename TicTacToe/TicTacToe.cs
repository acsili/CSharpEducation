﻿using System;

namespace TicTacToe
{
    public class TicTacToe
    {
        #region Constants

        /// <summary>
        /// Обозначение крестика.
        /// </summary>
        private static char symbolX = 'X';

        /// <summary>
        /// Обозначение нолика.
        /// </summary>
        private static char symbolO = 'O';

        #endregion

        #region Fields and Properties

        /// <summary>
        /// Запуск игры. true - запуск бесконечного цикла, false - заверщение программы.
        /// </summary>
        private static bool run = true;

        /// <summary>
        /// Доска, заполненная стандартными значениями.
        /// </summary>
        private static char[] board;

        /// <summary>
        /// Текущий игрок.
        /// </summary>
        private static int currentPlayer;

        #endregion

        #region Methods

        /// <summary>
        /// Запуск цикла для начала игры.
        /// </summary>
        public static void Start()
        {
            while (run)
            {
                DrawBoard();
                Console.WriteLine();

                bool inputValid;

                do
                {
                    Console.Write($"Ход {CheckXorO(currentPlayer)}: ");
                    inputValid = int.TryParse(Console.ReadLine(), out var choice) && choice >= 1 && choice <= 9 &&
                                    board[choice - 1] != 'X' && board[choice - 1] != 'O';

                    if (inputValid)
                    {
                        board[choice - 1] = CheckXorO(currentPlayer);
                    }
                    else
                    {
                        Console.WriteLine("Неверный ход!\n");
                    }
                } while (!inputValid);

                if (ItIsWin())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine($"Игрок {CheckXorO(currentPlayer)} победил!");
                    Stickman.StickmanJustJumping(currentPlayer);
                    StartNewGame();
                }

                if (ItIsDraw())
                {
                    Console.Clear();
                    DrawBoard();
                    Console.WriteLine("Ничья!");
                    StartNewGame();
                }

                currentPlayer = (currentPlayer == 1) ? 2 : 1;
            }
        }

        /// <summary>
        /// Проверка: текущий игрок X или O.
        /// </summary>
        /// <param name="currentPlayer">Текущий игрок.</param>
        /// <returns></returns>
        private static char CheckXorO(int currentPlayer)
            => currentPlayer == 1 ? 'X' : 'O';

        /// <summary>
        /// Отрисовка игрового поля.
        /// </summary>
        private static void DrawBoard()
        {
            Console.WriteLine("-------------");
            for (int i = 0; i < board.Length; i++)
            {
                Console.Write("| ");
                if (board[i] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(board[i]);
                }
                else if (board[i] == 'O')
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
        /// <returns></returns>
        private static bool ItIsWin()
        {
            return (board[0] == board[1] && board[1] == board[2]) || (board[3] == board[4] && board[4] == board[5]) ||
                   (board[6] == board[7] && board[7] == board[8]) || (board[0] == board[3] && board[3] == board[6]) ||
                   (board[1] == board[4] && board[4] == board[7]) || (board[2] == board[5] && board[5] == board[8]) ||
                   (board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]);
        }

        /// <summary>
        /// Проверка на ничью.
        /// </summary>
        /// <returns></returns>
        private static bool ItIsDraw()
        {
            foreach (var cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Начать новую игру. y - новая игра, n - завершение программы.
        /// </summary>
        private static void StartNewGame()
        {
            string newGame;
            do
            {
                Console.Write("Новая игра? [y/n] ");
                newGame = Console.ReadLine()!;
                if (newGame == "y")
                {
                    board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    currentPlayer = 1;

                    Console.Clear();
                    break;
                }
                else if (newGame == "n")
                {
                    run = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                }
            } while (true);
        }

        #endregion
    }
}
