using System;

namespace TicTacToe
{
    public class Player
    {
        public int m_Score { get; set; }
        public Cell.eSigns m_Sign { get; }
        public int m_Identifier { get; }
        public bool m_IsPc { get; }

        public Player(Cell.eSigns i_Sign, int i_Identifier ,bool i_IsPc)
        {
            m_Sign = i_Sign;
            m_Identifier = i_Identifier;
            m_IsPc = i_IsPc;
        }
    }
}