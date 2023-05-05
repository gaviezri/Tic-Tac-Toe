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
                if (input <= 3)
                {
                    // 
                    // handling user input for mode
                    // 
                }
                else
                {
                    break;
                }
            }
        }

        private void startGame(bool i_IsVersusPc)
        {
            int boardSize =  UI.PresentBoardSizeSelection();
            bool isGameOver = false;
            Board board = new Board(i_BoardSize);
            Player playerOne = new Player(Cell.eSigns.Cross);
            Player playerTwo = new Player(Cell.eSigns.Circle);

            while (!isGameOver)
            {
                int[] playerOneMove = UI.GetUserMove(board);
                board.MakeMove(playerOneMove[0], playerOneMove[1], playerOne.m_Sign);
                
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
                    int row = position / i_Board.m_Size;
                    int column = position % i_Board.m_Size;

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