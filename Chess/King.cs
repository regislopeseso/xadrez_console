using Boards;


namespace Chess
{
    public class King : Piece
    {
        private ChessMatch CurrentMatch;
        public King(Board board, Color color, ChessMatch currentMatch) : base(board, color)
        {
            this.CurrentMatch = currentMatch;
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

        private bool CanRookDoCastling(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p is Rook && p.Color == this.Color && p.CountMoves == 0;
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

            #region Castling (Special Move)
            if (CountMoves == 0 && CurrentMatch.Check == false)
            {
                //Small Castling
                Position rookPos1 = new Position(Position.Line, Position.Column + 3);
                if(CanRookDoCastling(rookPos1) == true)
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);
                    if(Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
                //Big Castling
                Position rookPos2 = new Position(Position.Line, Position.Column - 4);
                if (CanRookDoCastling(rookPos2) == true)
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);
                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column - 2] = true;
                    }
                }
            }
            #endregion

            return mat;
        }
    }
}