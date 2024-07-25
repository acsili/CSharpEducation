﻿using System;
using System.Threading;

bool run = true;
char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
int currentPlayer = 1; 

Main();

void Main()
{
    while (run)
    {
        DrawBoard();
        Console.WriteLine();

        bool inputValid;

        do
        {
            Console.Write($"Ход {(currentPlayer == 1 ? 'X' : 'O')}: ");
            inputValid = int.TryParse(Console.ReadLine(), out var choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';
            if (inputValid)
            {
                board[choice - 1] = (currentPlayer == 1) ? 'X' : 'O';
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
            Console.WriteLine($"Игрок {(currentPlayer == 1 ? 'X' : 'O')} победил!");
            StickmanJustJumping(currentPlayer);
            NewGame();
        }

        if (ItIsDraw())
        {
            Console.Clear();
            DrawBoard();
            Console.WriteLine("Ничья!");
            NewGame();
        }

        currentPlayer = (currentPlayer == 1) ? 2 : 1;
    }
}

// Отрисовка поля.
void DrawBoard()
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

// Проверка на победу игрока. 
bool ItIsWin()
{
    return (board[0] == board[1] && board[1] == board[2]) || (board[3] == board[4] && board[4] == board[5]) ||
           (board[6] == board[7] && board[7] == board[8]) || (board[0] == board[3] && board[3] == board[6]) ||
           (board[1] == board[4] && board[4] == board[7]) || (board[2] == board[5] && board[5] == board[8]) ||
           (board[0] == board[4] && board[4] == board[8]) || (board[2] == board[4] && board[4] == board[6]);
}

// Проверка на ничью
bool ItIsDraw()
{
    foreach (var cell in board)
    {
        if (cell != 'X' && cell != 'O')
            return false;
    }
    return true;
}

void NewGame()
{
    string newGame;
    do
    {
        Console.Write("Новая игра? [y/n] ");
        newGame = Console.ReadLine()!;
        if (newGame == "y")
        {
            board = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            currentPlayer = 2;
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


void StickmanJustJumping(int currentPlayer)
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

void DrawStickman(int position, int currentPlayer)
{
    Console.SetCursorPosition(0, position);
    Console.WriteLine($" {(currentPlayer == 1 ? 'X' : 'O')} ");
    Console.WriteLine("/|\\");
    Console.WriteLine("/ \\");
}

void DrawStickmanJump(int position, int currentPlayer)
{
    Console.SetCursorPosition(0, position);
    Console.WriteLine($"\\{(currentPlayer == 1 ? 'X' : 'O')}/");
    Console.WriteLine(" |");
    Console.WriteLine("/ \\");
}

void DrawNothing(int position)
{
    Console.SetCursorPosition(0, position);
    Console.WriteLine("   ");
    Console.WriteLine("   ");
    Console.WriteLine("   ");
}