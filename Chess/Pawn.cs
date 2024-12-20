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

        private bool IsOpponentThere(Position pos)
        {
            Piece p = Board.Piece(pos);
            return p != null && p.Color != this.Color;
        }

        private bool Free(Position pos)
        {
            return Board.Piece(pos) == null;
        }


        public override bool[,] PossibleMoves()
        {
            bool[,] mat = new bool[Board.Lines, Board.Columns];

            Position pos = new Position(0, 0);

            #region Movements
            if (Color == Color.Red)
            {
                pos.DefineValues(Position.Line - 1, Position.Column);
                if (Board.PositionIsValid(pos) == true && Free(pos) == true)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line - 2, Position.Column);
                Position p2 = new Position(Position.Line - 1, Position.Column);
                if (Board.PositionIsValid(pos) == true && Board.PositionIsValid(p2) == true && Free(pos) == true && Free(p2) == true && CountMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line - 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) == true && IsOpponentThere(pos) == true)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line - 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) && IsOpponentThere(pos) == true)
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            else
            {
                pos.DefineValues(Position.Line + 1, Position.Column);
                if (Board.PositionIsValid(pos) == true && Free(pos) == true)
                {
                    mat[pos.Line, pos.Column] = true;
                }
               
                pos.DefineValues(Position.Line + 2, Position.Column);
                Position p2 = new Position(Position.Line + 1, Position.Column);
                if (Board.PositionIsValid(pos) == true && Board.PositionIsValid(p2) == true && Free(pos) == true && Free(p2) == true && CountMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line + 1, Position.Column - 1);
                if (Board.PositionIsValid(pos) == true && IsOpponentThere(pos) == true)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                
                pos.DefineValues(Position.Line + 1, Position.Column + 1);
                if (Board.PositionIsValid(pos) == true && IsOpponentThere(pos) == true)
                {
                    mat[pos.Line, pos.Column] = true;
                }
            }
            #endregion

            return mat;
        }
    }
}

