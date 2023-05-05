using System;

namespace TicTacToe
{
    public class Game
    {
        public void Run()
        {
            while (true)
            {
                UserInterface.PresentMainMenu();
                int input = UserInterface.GetUserInput(UserInterface.k_MenuFirst, UserInterface.k_MainMenuLast);
                if (input < UserInterface.k_MainMenuLast)
                {
                    handleUserInputForMode(input);
                }
                else
                {
                    break;
                }
            }
        }

        private void startGame(bool i_IsVersusPc)
        {
            UserInterface.PresentBoardSizeSelection();
            int boardSize = UserInterface.GetUserInput(UserInterface.k_BoardSizeMin, UserInterface.k_BoardSizeMax);
            Player playerOne = new Player(Cell.eSigns.Cross, 1, false);
            Player playerTwo = new Player(Cell.eSigns.Circle, 2, i_IsVersusPc);
            while (true)
            {
                singleGame(playerOne, playerTwo, boardSize, i_IsVersusPc);
                UserInterface.PresentScoreBoard(playerOne, playerTwo, i_IsVersusPc);
                if (!UserInterface.AskForAnotherRound())
                {
                    break;
                }
            }
        }

        private void singleGame(Player i_PlayerOne, Player i_PlayerTwo, int i_BoardSize, bool i_IsVersusPc)
        {
            Board board = new Board(i_BoardSize);
            Player[] players = { i_PlayerOne, i_PlayerTwo };
            int turnCounter = 0;
            while (board.IsBoardNotFull())
            {
                UserInterface.PrintBoard(board);
                if (singleTurn(players[turnCounter % 2], board, i_IsVersusPc, out bool isQuit))
                {
                    if (!isQuit)
                    {
                        players[(turnCounter + 1) % 2].m_Score++;
                    }
                    
                    break;
                }
                
                turnCounter++;
            }
            
            if (!board.IsBoardNotFull())
            {
                UserInterface.PrintGameOverFullBoard();
            }
        }

        private bool singleTurn(Player i_Player, Board board, bool i_IsVersusPc, out bool o_IsQuit)
        {
            bool isGameOver = false;
            int[] playerMove = new int[2];
            o_IsQuit = false;
            if (i_Player.m_isPc)
            {
                playerMove = getPcMove(board);
            }
            else
            {
                playerMove = UserInterface.GetUserMove(board, out o_IsQuit);
            }

            if (!o_IsQuit)
            {
                board.MakeMove(playerMove[0] - 1, playerMove[1] - 1, i_Player.m_Sign);
                if (checkIfPlayerLost(i_Player, board))
                {
                    UserInterface.CongratulatePlayer(i_Player, i_IsVersusPc);
                    isGameOver = true;
                }
            }
            else
            {
                isGameOver = true;
            }
            
            return isGameOver;
        }

        private void handleUserInputForMode(int i_Input)
        {
            switch (i_Input)
            {
                case UserInterface.k_PlayerVsPlayer:
                    startGame(false);
                    break;
                case UserInterface.k_PlayerVsComputer:
                    startGame(true);
                    break;
                case UserInterface.k_Instructions:
                    UserInterface.PresentInstructions();
                    break;
            }
        }

        private int[] getPcMove(Board i_Board)
        {
            Random random = new Random();
            int randomRow = random.Next();
            int randomColumn = random.Next();
            while (!i_Board.IsValidMove(randomRow, randomColumn))
            {
                randomRow = random.Next();
                randomColumn = random.Next();
            }

            int[] randomMove = { randomRow, randomColumn };
            return randomMove;
        }
     
        private bool checkIfPlayerLost(Player i_Player, Board i_Board)
        {
            bool hasPlayerLost = false;
            
            foreach (int[] combination in i_Board.m_LosingCombinations)
            {
                bool isLosingCombination = true;
                foreach (int position in combination)
                {
                    int row = position / i_Board.Size;
                    int column = position % i_Board.Size;

                    if (i_Board.m_Cells[row, column].Sign != i_Player.m_Sign)
                    {
                        isLosingCombination = false;
                        break;
                    }
                }

                if (isLosingCombination)
                {
                    hasPlayerLost = true;
                    break;
                }
            }

            return hasPlayerLost;
        }
    }
}