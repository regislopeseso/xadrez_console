using Boards;


namespace Chess
{
    public class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
