namespace TicTacToe
{
    public class Game
    {
        public void Run()
        {
            while (true)
            {
                UI.PresentMainMenu();
                int input = UI.GetUserInput(UI.k_MenuFirst, UI.k_MainMenuLast);
                if (input < UI.k_MainMenuLast)
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
            UI.PresentBoardSizeSelection();
            int boardSize = UI.GetUserInput(UI., )
            bool isGameOver = false;
            Board board = new Board(i_BoardSize);
            Player playerOne = new Player(Cell.eSigns.Cross);
            Player playerTwo = new Player(Cell.eSigns.Circle);

            while (!isBoardFull)
            {
                int[] playerOneMove = UI.GetUserMove(board);
                board.MakeMove(playerOneMove[0], playerOneMove[1], playerOne.m_Sign);
                if (checkIfPlayerLost(playerOne, board))
                {
                    UI.CongratulatePlayer(2);
                    break;
                }
                int[] playerTwoMove = UI.GetUserMove(board);
                board.MakeMove(playerTwoMove[0], playerTwoMove[1], playerTwo.m_Sign);
                if (checkIfPlayerLost(playerTwo, board))
                {
                    UI.CongratulatePlayer(1);
                    break;
                }
            }

            if (isBoardFull)
            {
                UI.PrintGameOverFullBoard();
            }
        }
        
        
        private void handleUserInputForMode(int i_Input)
        {
            switch (i_Input)
            {
                case UI.k_PlayerVsPlayer:
                    //foo(true);
                    break;
                case UI.k_PlayerVsComputer:
                    //foo(false);
                    break;
                case UI.k_Instructions:
                    UI.PresentInstructions();
                    break;
            }
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