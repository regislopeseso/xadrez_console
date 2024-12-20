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
            return "B";
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

            #region (NE) Northeast direction
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            while (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
                if (Board.Piece(pos) != null && Board.Piece(pos).Color != this.Color )
                {
                    break;                  
                }
                pos.DefineValues(pos.Line - 1, pos.Column + 1);
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
