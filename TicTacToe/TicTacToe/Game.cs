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