using Boards;

namespace Chess
{
    public class Pawn : Piece
    {            
        private ChessMatch CurrentMatch;

        public Pawn(Board board, Color color, ChessMatch currentMatch) : base(board, color)
        {
            this.CurrentMatch = currentMatch;
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
            #region Red Pieces
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

                #region EN PASSANT (Special Move)
                if(Position.Line == 3)
                {
                    Position onTheLeft = new Position(Position.Line, Position.Column - 1);
                    if (Board.PositionIsValid(onTheLeft) == true && IsOpponentThere(onTheLeft) && Board.Piece(onTheLeft) == this.CurrentMatch.VulnerableToEnPassant)
                    {
                        mat[onTheLeft.Line - 1, onTheLeft.Column] = true;
                    }

                    Position onTheRight = new Position(Position.Line, Position.Column + 1);
                    if (Board.PositionIsValid(onTheRight) == true && IsOpponentThere(onTheRight) && Board.Piece(onTheRight) == this.CurrentMatch.VulnerableToEnPassant)
                    {
                        mat[onTheRight.Line - 1, onTheRight.Column] = true;
                    }
                }
                #endregion
            }
            #endregion

            #region Yellow Pieces
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

                #region EN PASSANT (Special Move)
                if (Position.Line == 4)
                {
                    Position onTheLeft = new Position(Position.Line, Position.Column - 1);
                    if (Board.PositionIsValid(onTheLeft) == true && IsOpponentThere(onTheLeft) && Board.Piece(onTheLeft) == this.CurrentMatch.VulnerableToEnPassant)
                    {
                        mat[onTheLeft.Line + 1, onTheLeft.Column] = true;
                    }

                    Position onTheRight = new Position(Position.Line, Position.Column + 1);
                    if (Board.PositionIsValid(onTheRight) == true && IsOpponentThere(onTheRight) && Board.Piece(onTheRight) == this.CurrentMatch.VulnerableToEnPassant)
                    {
                        mat[onTheRight.Line + 1, onTheRight.Column] = true;
                    }
                }
                #endregion
            }
            #endregion
            #endregion
            return mat;
        }
    }
}

