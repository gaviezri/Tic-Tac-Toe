namespace TicTacToe
{
    public class Game
    {
        private Board board = null;

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