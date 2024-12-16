using Boards;
using Chess;

namespace xadrez_console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var board = new Board(8, 8);


                board.PlaceAPiece(new Rook(board, Color.Black), new Position(0, 0));
                board.PlaceAPiece(new Rook(board, Color.Black), new Position(1, 3));
                board.PlaceAPiece(new King(board, Color.Black), new Position(2, 4));

                board.PlaceAPiece(new Rook(board, Color.White), new Position(3, 5));

                Screen.DisplayBoard(board);

                //ChessPosition pos = new ChessPosition('a',1);

                //Console.WriteLine(pos);

                //Console.WriteLine(pos.ConvertPosition());


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}