﻿using Boards;


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



        public override bool[,] PossibleMoves()
        {
            throw new NotImplementedException();
        }
    }
}
