namespace TicTacToe
{
    public class Cell
    {
        public eSigns m_Sign = eSigns.Empty;

        public enum eSigns
        {
            Empty,
            Circle,
            Cross
        }
    }
}