namespace TicTacToe
{
    public class Player
    {
        private int m_Score { get; set; }
        public char m_Identifier { get; }
        public char m_Sign { get; }

        public Player()
        {
            m_Identifier = '1';
            m_Sign = 'X';
        }
    }
}