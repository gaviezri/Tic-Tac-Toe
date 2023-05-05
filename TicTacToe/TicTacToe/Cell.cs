namespace TicTacToe
{
    public class Cell
    {
        private eSigns m_Sign = eSigns.Empty;
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

        public enum eSigns
        {
            Empty,
            Circle,
            Cross
        }
    }
}