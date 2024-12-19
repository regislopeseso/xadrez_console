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
                    try
                    {
                        Console.Clear();
                        Screen.ShowMatch(match);  

                        Console.Write("\nOrigin: ");
                        var originInput = Screen.ReadChessPosition();
                        Position origin = originInput.ConvertPosition();
                        match.ValidateOriginPosition(origin);

                        bool[,] possibleMoves = match.Board.Piece(origin).PossibleMoves();

                        Console.Clear();

                        Screen.DisplayBoard(match.Board, possibleMoves, origin);
                        Console.WriteLine($"\nOrigin: {originInput}");
                        Console.Write("Target: ");
                        Position target = Screen.ReadChessPosition().ConvertPosition();
                        match.ValidateTargetPosition(origin, target);

                        match.Play(origin, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
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