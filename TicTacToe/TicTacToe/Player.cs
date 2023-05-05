using System;

namespace TicTacToe
{
    public class Player
    {
        private static int s_PlayerCount = 0;
        private int m_Score { get; set; }
        public char m_Identifier { get; }
        public Cell.eSigns m_Sign { get; set; }

        public Player(Cell.eSigns i_Sign)
        {
            s_PlayerCount++;
            m_Identifier = (char) s_PlayerCount;
            m_Sign = Cell.eSigns.Cross;
        }
        ~Player()
        {
            s_PlayerCount--;
        }
    }
}