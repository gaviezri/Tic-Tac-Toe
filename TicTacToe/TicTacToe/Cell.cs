namespace TicTacToe
{
    public struct Cell
    {
        private eSigns m_Sign;

        public eSigns Sign
        {
            get
            {
                return m_Sign;
            }
            set
            {
                m_Sign = value;
            }
        }

        public Cell(eSigns i_Sign)
        {
            m_Sign = eSigns.Empty;
            m_Sign = i_Sign;
        }

        public Cell.eSigns Sign
        {
            get
            {
                return m_Sign;
            }
            set
            {
                m_Sign = value;
            }
        }
        
        public string eSignToString() 
        {
            string signChar="";
            switch(m_Sign)
            {
                case eSigns.Circle:
                    signChar = "O";
                    break;
                case eSigns.Cross:
                    signChar = "X";
                    break;
                case eSigns.Empty:
                    signChar = " ";
                    break;
            }
            return signChar;
        }
        public enum eSigns
        {
            Empty,
            Circle,
            Cross     
        }

    }
}