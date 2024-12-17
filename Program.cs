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
                ChessMatch match = new ChessMatch();
                while (match.IsFinished != true)
                {
                    Console.Clear();
                    Screen.DisplayBoard(match.Board);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ConvertPosition();
                    Console.Write("Target: ");
                    Position target = Screen.ReadChessPosition().ConvertPosition();

                    match.MovePiece(origin, target);
                }







            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}