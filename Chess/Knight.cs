using Boards;


namespace Chess
{
    public class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "k";
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

            #region L simple upward right
            pos.DefineValues(Position.Line + 1, Position.Column + 2);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            
            #region L double upward right
            pos.DefineValues(Position.Line + 2, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            
            
            #region L simple downward right
            pos.DefineValues(Position.Line - 1, Position.Column + 2);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            
            #region L double downward right
            pos.DefineValues(Position.Line - 2, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
           

            #region L simple downward left
            pos.DefineValues(Position.Line - 1, Position.Column - 2);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true) 
            {
                mat[pos.Line, pos.Column] = true;                    
            }
            #endregion
            
            #region L double downward left
            pos.DefineValues(Position.Line - 2, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion


            #region L simple upward left
            pos.DefineValues(Position.Line + 2, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            
            #region L double upward left
            pos.DefineValues(Position.Line + 1, Position.Column - 2);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            #endregion
            
            return mat;
        }    
    }
}
