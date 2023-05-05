namespace TicTacToe
{
    public class Player
    {
        public int m_Score { get; set; }
        public Cell.eSigns m_Sign { get; }

        public Player(Cell.eSigns i_Sign)
        {
            m_Sign = i_Sign;
        }
    }
}