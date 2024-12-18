using Boards;


namespace Chess
{
    public class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }


        public override string ToString()
        {
            return "T";
        }
        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
