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
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column);
            }
            #endregion

            #region (NE) Northeast direction
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
            }
            #endregion

            #region (E) East direction
            pos.DefineValues(Position.Line, Position.Column + 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line, pos.Column + 1);
            }
            #endregion

            #region (SE) Southeast direction
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column + 1);
            }
            #endregion

            #region (S) South direction
            pos.DefineValues(Position.Line + 1, Position.Column);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column);
            }
            #endregion

            #region (SW) Southwest direction
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line + 1, pos.Column - 1);
            }
            #endregion

            #region (W) West direction
            pos.DefineValues(Position.Line, Position.Column - 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line, pos.Column - 1);
            }
            #endregion

            #region (NW) Northwest direction
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color)
                {
                    break;
                }
                pos.DefineValues(pos.Line - 1, pos.Column - 1);
            }
            #endregion

            return mat;
        }
    }
}
