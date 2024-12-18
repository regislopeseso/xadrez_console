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

                    Console.WriteLine($"\nTurn: {match.Turn}");
                    Console.WriteLine($"Waiting for {match.CurrentPlayer} Player to play");         

                    Console.Write("\nOrigin: ");
                    var originInput = Screen.ReadChessPosition();
                    Position origin = originInput.ConvertPosition();

                    bool[,] possibleMoves = match.Board.Piece(origin).PossibleMoves();

                    Console.Clear();

                    Screen.DisplayBoard(match.Board, possibleMoves);
                    Console.WriteLine($"\nOrigin: {originInput}");
                    Console.Write("Target: ");
                    Position target = Screen.ReadChessPosition().ConvertPosition();

                    match.ExecuteMove(origin,target);
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