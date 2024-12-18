using Boards;


namespace Chess
{
    public class Pawn : Piece
    {
        public Pawn(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
