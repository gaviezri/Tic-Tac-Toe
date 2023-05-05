﻿using System;
using Ex02.ConsoleUtils;

namespace TicTacToe
{
    public class UserInterface
    {   
        const string k_InvalidMoveMessage = "Invalid move, please try again:";
        const string k_InvalidInputMessage = "Invalid format try again, enter ROW# space COL#\nwith values that correspond to the board:";
        const string k_LineDeleter = "                                                    ";
        public const int k_MenuFirst = 1;
        public const int k_MainMenuLast = 4;
        public const int k_PlayerVsPlayer = 1;
        public const int k_PlayerVsComputer = 2;
        public const int k_Instructions = 3;
        public const int k_BoardSizeMin = 3;
        public const int k_BoardSizeMax = 9;

        public static void PrintBoard(Board board)
        {
            Screen.Clear();
            PrintRowHeader(board.Size);
            for (int i = 0; i < board.Size; i++)
            {
                PrintRow(board, i);
            }
        }

        private static void PrintRowHeader(int i_Size)
        {
            for (int i = 0; i < i_Size; i++)
            {
                Console.Write("   {0}", (char)('1' + i));
            }
            Console.WriteLine();
            
        }

        private static void PrintRow(Board board, int i_Row)
        {
            
            for(int i = 0; i < board.Size; i++)
            {
                if (i == 0)
                {
                    Console.Write("{0}|", (char)('1' + i_Row));
                }
                Console.Write(" {0} ", board.GetCell(i_Row, i).eSignToString());
                if (i < board.Size)
                {
                    Console.Write("|");
                }
                if (i == board.Size - 1)
                {
                    Console.WriteLine();
                }

            }
            PrintRowSeperator(board.Size);
        }

        private static void PrintRowSeperator(int i_Size)
        {
            Console.Write(" ");
            for (int i = 0; i < i_Size; i++)
            {
                Console.Write("====");
            }
            Console.Write("=");
            Console.WriteLine();
        }

        public static int[] GetUserMove(Board i_Board, out bool o_Quit)
        {
            // if method returns null, user wants to quit
            // else, user's move is returned as string array string[row, col]
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            bool isValidMove = false;
            string[] movesInput = null;
            o_Quit = false;

            Console.Write("Please enter your move [ROW#] [COL#]:");
            while (!isValidMove)
            {
                string move = Console.ReadLine();
                movesInput = move.Split(' ');
                if (move == "Q")
                {
                    movesInput = null;
                    isValidMove = true;
                    o_Quit = true;
                }
                if (movesInput.Length == 2 && move.Length == 3) 
                {
                    try
                    {
                        if (!i_Board.IsValidMove(int.Parse(movesInput[0]), int.Parse(movesInput[1])))
                        {
                            Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                            Console.Write(k_InvalidMoveMessage);
                        }
                        else { isValidMove = true;}
                    }
                    catch (Exception)
                    {
                        Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                        Console.Write(k_LineDeleter);
                        Console.Write(k_InvalidInputMessage);
                    }
                }
                else 
                {   Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write(k_InvalidInputMessage);
                }
            }

            int[] moves = new int[2];

            for (int i = 0; i < movesInput.Length; i++)
            {
                int.TryParse(movesInput[i], out moves[i]);
            }
            
            return moves;
        }
        
        public static void CongratulatePlayer(Player i_PlayerWhoLost, bool i_IsVsPc)
        {
            if (i_IsVsPc)
            {
                if (i_PlayerWhoLost.m_isPc)
                {
                    Console.WriteLine("You won! Congratulations!");
                }
                else
                {
                    Console.WriteLine("You lost! Better luck next time!");
                }
            }
            else
            {
                Console.WriteLine("Player {0} won! Congratulations!", 3 - i_PlayerWhoLost.m_Identifier);
            }
        }

        public static void PrintGameOverFullBoard()
        {
            Console.WriteLine("Yikes! Board is full so game ended as a draw!");
        }

        public static void PresentScoreBoard(Player i_PlayerOne, Player i_PlayerTwo, bool i_IsVsPc)
        {
            Screen.Clear();
            Console.WriteLine("Current Scoreline:");
            if (i_IsVsPc)
            {
                Console.WriteLine("Player: {0}  Computer: {1}", i_PlayerOne.m_Score, i_PlayerTwo.m_Score);
            }
            else
            {
                Console.WriteLine("Player-One: {0}  Player-Two: {1}", i_PlayerOne.m_Score, i_PlayerTwo.m_Score);
            }
        }

        public static bool AskForAnotherRound()
        {
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Play another round");
            Console.WriteLine("2. Return to main menu");
            int userInput = GetUserInput(1, 2);
            return userInput == 1;
        }

        public static void PresentMainMenu()
        {
            Console.WriteLine("Welcome to Reverse-TicTacToe!");
            Console.WriteLine("=============================");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Play against a friend");
            Console.WriteLine("2. Play against the computer");
            Console.WriteLine("3. Instructions");
            Console.WriteLine("4. Quit");
        }

        public static void PresentBoardSizeSelection()
        {
            Screen.Clear();
            Console.WriteLine("Choose Board Size [3~9]");
        }   
        
        public static int GetUserInput(int i_LowerBound, int i_UpperBound)
        {
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            bool isValidInput = false;
            int result = 0;
            while (!isValidInput)
            {
                Console.Write("Selection: ");
                string input = Console.ReadLine();
                try
                {
                    int inputAsInt = int.Parse(input);
                    if (inputAsInt >= i_LowerBound && inputAsInt <= i_UpperBound)
                    {
                        isValidInput = true;
                        result = inputAsInt;
                    }
                    else
                    {   
                        Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                        Console.Write(UserInterface.k_LineDeleter);
                        Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                        Console.Write("Invalid input, please try again:");
                    }
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write(UserInterface.k_LineDeleter);
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write("Invalid input, please try again:");
                }
            }
            return result;
        }

        public static void PresentInstructions()
        {
            Screen.Clear();
            Console.WriteLine("Instructions:");
            Console.WriteLine("=============");
            Console.WriteLine("The game is played on a grid that's N by N.");
            Console.WriteLine("The first player to get N of his signs in a row, column or diagonal LOSES!");
            Console.WriteLine("The game ends in a tie if the board is full and no player has Lost.");
            Console.WriteLine("so... you don't want to be the first to achieve a streak of N");
            Console.WriteLine("Good luck!");
            Console.WriteLine("Press any key to go back to main menu");
            Console.ReadKey();
        }
    }
}
