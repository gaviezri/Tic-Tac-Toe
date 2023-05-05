using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02.ConsoleUtils;

namespace TicTacToe
{
    public class UI
    {   
        const string k_InvalidMoveMessage = "Invalid move, please try again:";
        const string k_InvalidInputMessage = "Invalid format try again, enter ROW# space COL#\nwith values that correspond to the board:";
        const string k_LineDeleter = "                                                    ";
        public const int k_MenuFirst = 1;
        public const int k_MainMenuLast = 4;
        public const int k_GameModeLast = 3;
        private UI() { }

        public static void PrintBoard(Board board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
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

        public static int[] GetUserMove(Board i_Board)
        {
            // if method returns null, user wants to quit
            // else, user's move is returned as string array string[row, col]
            int originalCursorLeft = Console.CursorLeft;
            int originalCursorTop = Console.CursorTop;
            bool isValidMove = false;
            string[] movesInput = null;

            Console.Write("Please enter your move [ROW#] [COL#]:");
            while (!isValidMove)
            {
                string move = Console.ReadLine();
                movesInput = move.Split(' ');
                if (move == "Q")
                {
                    movesInput = null;
                    isValidMove = true;
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

        public static void PresentGameModeSelection()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Choose Game Mode:");
            Console.WriteLine("=================");
            Console.WriteLine("1. Player vs. Player");
            Console.WriteLine("2. Player vs. Computer");
            Console.WriteLine("3. Go back to main menu");
        }
        
        public static void PresentBoardSizeSelection()
        {
            Ex02.ConsoleUtils.Screen.Clear();
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
                        Console.Write(UI.k_LineDeleter);
                        Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                        Console.Write("Invalid input, please try again:");
                    }
                }
                catch (Exception e)
                {
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write(UI.k_LineDeleter);
                    Console.SetCursorPosition(originalCursorLeft, originalCursorTop);
                    Console.Write("Invalid input, please try again:");
                }
            }
            return result;
        }
    }
}
