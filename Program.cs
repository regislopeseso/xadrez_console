using Boards;
using Chess;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var board= new Board(8, 8);
            

            board.PlaceAPiece(new Rook(board, Color.Black), new Position(0, 0));
            board.PlaceAPiece(new Rook(board, Color.Black), new Position(1, 3));
            board.PlaceAPiece(new King(board, Color.Black), new Position(2, 4));
            
            Screen.DisplayBoard(board);

            Console.ReadLine();

        }
    }
}