using Boards;


namespace Chess
{
    public class King : Piece
    {
        public King(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "K";
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
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (NE) Northeast direction
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (E) East direction
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (SE) Southeast direction
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (S) South direction
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (SW) Southwest direction
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (W) West direction
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            #region (NW) Northwest direction
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion

            return mat;
        }
    }
}