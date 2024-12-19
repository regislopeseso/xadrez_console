using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    public abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int CountMoves { get; protected set;}
        public Board Board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.Position = null;
            this.Board = board;
            this.Color = color;
            this.CountMoves = 0;
        }
        
        public void IncreaseCountMoves()
        {
            this.CountMoves++; 
        }

        public void DecreaseCountMoves()
        {
            this.CountMoves--;
        }

        public bool AreTherePossibleMoves()
        {
            bool[,] mat = PossibleMoves();
            for (int i = 0; i < Board.Lines; i++)
            {
                for(int j= 0; j < Board.Columns; j++)
                {
                    if (mat[i, j] == true)
                    {
                        return true;
                    }                
                }
            }
            return false;
        }

        public bool canMoveTo(Position pos)//nothing changed this name is cool =)
        {
            return PossibleMoves()[pos.Line, pos.Column];
        }
        public abstract bool[,] PossibleMoves();
    }
}
