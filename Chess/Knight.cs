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

        #region A seguinte regra de movimento é para Reis, portanto deve ser corrigida!
        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            //north direction
            pos.DefineValues(Position.Line - 1, Position.Column);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //northeast direction
            pos.DefineValues(Position.Line - 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //east direction
            pos.DefineValues(Position.Line, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //southeast direction
            pos.DefineValues(Position.Line + 1, Position.Column + 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //south direction
            pos.DefineValues(Position.Line + 1, Position.Column);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //southwest direction
            pos.DefineValues(Position.Line + 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //west direction
            pos.DefineValues(Position.Line, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            //northwest direction
            pos.DefineValues(Position.Line - 1, Position.Column - 1);
            if (Board.PositionIsValid(pos) == true && IsSpotFree(pos) == true)
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
        #endregion
    }
}
