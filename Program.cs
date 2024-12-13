using Boards;



namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var chessBoard = new Board(8, 8);
            
            Screen.DisplayBoard(chessBoard);

            Console.ReadLine();

        }
    }
}