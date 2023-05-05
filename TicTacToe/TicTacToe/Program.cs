namespace TicTacToe
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            UI.presentMainMenu();
            UI.GetUserInput(UI.k_MainMenuFirst, UI.k_MainMenuLast);
            Board board = new Board(3);
            UI.PrintBoard(board);
            UI.GetUserMove(board);
            System.Console.ReadLine();
            
        }
    }
}