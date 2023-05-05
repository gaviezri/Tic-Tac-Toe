namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            UI.PresentMainMenu();
            UI.GetUserInput(UI.k_MenuFirst, UI.k_MainMenuLast);
            Board board = new Board(3);
            UI.PrintBoard(board);
            UI.GetUserMove(board);
            System.Console.ReadLine();
            
        }
    }
}