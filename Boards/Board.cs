using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    public class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            this.pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return this.pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return this.pieces[pos.line, pos.column];
        }

        public bool ExistPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }
        public void PlacePiece(Piece p, Position pos)
        {
            if (ExistPiece(pos) == true) 
            {
                throw new BoardException("There is already a piece on this position!");
            }
            this.pieces[pos.line,pos.column] = p;
        }

        public Piece RemovePiece(Position pos)
        {
            if (piece(pos) == null)
            {
                return null;
            }
            else
            {
                Piece aux = piece(pos);
                aux.position = null;
                pieces[pos.line, pos.column] = null;
                return aux;
            }
        }

        public bool PositionIsValid(Position pos)
        {
            if (pos.line < 0 || pos.line >= this.lines || pos.column < 0 || pos.column >= this.columns) return false;
            else return true;
        }

        public void validatePosition(Position pos)
        {
            if (PositionIsValid(pos) != true)
            {
                throw new BoardException("Invalid position!");
            }
        }

    }
}
