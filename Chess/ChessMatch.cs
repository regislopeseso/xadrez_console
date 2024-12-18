using Boards;

namespace Chess
{
    class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool IsFinished { get; private set; }

        public ChessMatch()
        {
            this.Board = new Board(8, 8);
            this.Turn = 1;
            this.CurrentPlayer = Color.White;
            this.IsFinished = false;
            PlacePieces();
        }
        public void ExecuteMove(Position origin, Position target)
        {
            MovePiece(origin, target);
            this.Turn++;
            ChangePlayer();
        }
        private void ChangePlayer()
        {
            if (this.CurrentPlayer == Color.White)
            {
                this.CurrentPlayer = Color.Black;
            }
            else
            {
                this.CurrentPlayer = Color.White;
            }
        }
        public void MovePiece(Position origin, Position target)
        {
            Piece p = Board.RemovePiece(origin);
            p.nMovesUpdate();
            Piece pieceCaptured = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
        }
        public void PlacePieces()
        {
            //Placing all white pieces for a new match. . .
            this.Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('a', 1).ConvertPosition());
            this.Board.PlacePiece(new Knight(Board, Color.White), new ChessPosition('b', 1).ConvertPosition());
            this.Board.PlacePiece(new Bishop(Board, Color.White), new ChessPosition('c', 1).ConvertPosition());
            this.Board.PlacePiece(new Queen(Board, Color.White), new ChessPosition('d', 1).ConvertPosition());
            this.Board.PlacePiece(new King(Board, Color.White), new ChessPosition('e', 1).ConvertPosition());
            this.Board.PlacePiece(new Bishop(Board, Color.White), new ChessPosition('f', 1).ConvertPosition());
            this.Board.PlacePiece(new Knight(Board, Color.White), new ChessPosition('g', 1).ConvertPosition());
            this.Board.PlacePiece(new Rook(Board, Color.White), new ChessPosition('h', 1).ConvertPosition());

            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('a', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('b', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('c', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('d', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('e', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('f', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('g', 2).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.White), new ChessPosition('h', 2).ConvertPosition());

            //Placing all black pieces for a new match...
            this.Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('a', 8).ConvertPosition());
            this.Board.PlacePiece(new Knight(Board, Color.Black), new ChessPosition('b', 8).ConvertPosition());
            this.Board.PlacePiece(new Bishop(Board, Color.Black), new ChessPosition('c', 8).ConvertPosition());
            this.Board.PlacePiece(new Queen(Board, Color.Black), new ChessPosition('d', 8).ConvertPosition());
            this.Board.PlacePiece(new King(Board, Color.Black), new ChessPosition('e', 8).ConvertPosition());
            this.Board.PlacePiece(new Bishop(Board, Color.Black ), new ChessPosition('f', 8).ConvertPosition());
            this.Board.PlacePiece(new Knight(Board, Color.Black), new ChessPosition('g', 8).ConvertPosition());
            this.Board.PlacePiece(new Rook(Board, Color.Black), new ChessPosition('h', 8).ConvertPosition());

            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('a', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('b', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('c', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('d', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('e', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('f', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('g', 7).ConvertPosition());
            this.Board.PlacePiece(new Pawn(Board, Color.Black), new ChessPosition('h', 7).ConvertPosition());
        }
    }
}
