﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boards
{
    public class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int nMoves { get; protected set;}
        public Board board { get; protected set; }

        public Piece(Board board, Color color)
        {
            this.position = null;
            this.board = board;
            this.color = color;
            this.nMoves = 0;
        }
        
        public void nMovesUpdate()
        {
            this.nMoves ++; 
        }
    }
}
