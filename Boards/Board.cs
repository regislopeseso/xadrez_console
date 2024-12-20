using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    public class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            this.Lines = lines;
            this.Columns = columns;
            this.Pieces = new Piece[lines, columns];
        }

        public Piece Piece(int line, int column)
        {
            return this.Pieces[line, column];
        }

        public Piece Piece(Position pos)
        {
            return this.Pieces[pos.Line, pos.Column];
        }

        public bool ExistPiece(Position pos)
        {
            ValidatePosition(pos);
            return this.Piece(pos) != null;
        }
        public void PlacePiece(Piece p, Position pos)
        {
            if (ExistPiece(pos) == true) 
            {
                throw new BoardException("There is already a piece on this position!");
            }
            this.Pieces[pos.Line,pos.Column] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if (this.Piece(pos) == null)
            {
                return null;
            }
            else
            {
                Piece aux = this.Piece(pos);
                aux.Position = null;
                this.Pieces[pos.Line, pos.Column] = null;
                return aux;
            }
        }

        public bool PositionIsValid(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= this.Lines || pos.Column < 0 || pos.Column >= this.Columns) return false;
            else return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (PositionIsValid(pos) == false)
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
