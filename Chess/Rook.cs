using Boards;


namespace Chess
{
    public class Rook : Piece
    {
        public Rook(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool IsSpotFree(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p == null || p.Color != this.Color;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            #region (N) North direction
            pos.DefineValues(Position.Line - 1, Position.Column);
            while (Board.PositionIsValid(pos) && IsSpotFree(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }
            #endregion
            #region (S) South direction
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.PositionIsValid(pos) && IsSpotFree(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }
            #endregion
            #region (E) East direction
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.PositionIsValid(pos) && IsSpotFree(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }
            #endregion
            #region (W) West direction
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.PositionIsValid(pos) && IsSpotFree(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }
            #endregion



            return mat;
        }
    }
}
