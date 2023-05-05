namespace TicTacToe
{
    public struct Cell
    {
        private eSigns m_Sign;
        public Cell(eSigns i_Sign)
        {
            m_Sign = i_Sign;
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