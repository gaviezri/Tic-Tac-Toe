using System;

namespace TicTacToe
{
    public class Player
    {
        public int m_Score { get; set; }
        public Cell.eSigns m_Sign { get; }
        private static int s_PlayerCount;
        public char m_Identifier { get; }

        public Player(Cell.eSigns i_Sign)
        {
            s_PlayerCount++;
            m_Identifier = (char) s_PlayerCount;
            m_Sign = i_Sign;
        }
    }
}