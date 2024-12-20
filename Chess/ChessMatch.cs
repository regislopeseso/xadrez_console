﻿using Boards;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Chess
{
    public class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool IsFinished { get; private set; }
        private HashSet<Piece> Pieces;
        private HashSet<Piece> Captured;
        public bool Check { get; private set; }
        public Piece VulnerableToEnPassant { get; private set; }

        public ChessMatch()
        {
            this.Board = new Board(8, 8);
            this.Turn = 1;
            this.CurrentPlayer = Color.Red;
            this.IsFinished = false;
            this.Check = false;
            this.VulnerableToEnPassant = null;
            this.Pieces = new HashSet<Piece>();
            this.Captured = new HashSet<Piece>();
            PlacePieces();
        }
        public Piece ExecuteMove(Position origin, Position target)
        {
            Piece p = Board.RemovePiece(origin);
            p.IncreaseCountMoves();
            Piece pieceCaptured = Board.RemovePiece(target);
            Board.PlacePiece(p, target);
            if (pieceCaptured != null)
            {
                Captured.Add(pieceCaptured);
            }

            #region Castling (Special Move)
            //Small Castling
            if (p is King && target.Column == origin.Column + 2)
            {
                Position rookOriginPosition = new Position(origin.Line, origin.Column + 3);
                Position rookTargetPosition = new Position(origin.Line, origin.Column + 1);
                Piece R = Board.RemovePiece(rookOriginPosition);
                R.IncreaseCountMoves();
                Board.PlacePiece(R, rookTargetPosition);
            }

            //Big Castling
            if (p is King && target.Column == origin.Column - 2)
            {
                Position rookOriginPosition = new Position(origin.Line, origin.Column - 4);
                Position rookTargetPosition = new Position(origin.Line, origin.Column - 1);
                Piece R = Board.RemovePiece(rookOriginPosition);
                R.IncreaseCountMoves();
                Board.PlacePiece(R, rookTargetPosition);
            }
            #endregion

            #region EN PASSANT (Special Move)
            if (p is Pawn)
            {
                if (origin.Column != target.Column && pieceCaptured == null)
                {
                    Position pawnPosition;
                    if (p.Color == Color.Red)
                    {
                        pawnPosition = new Position(target.Line + 1, target.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(target.Line - 1, target.Column);
                    }
                    pieceCaptured = Board.RemovePiece(pawnPosition);
                    Captured.Add(pieceCaptured);
                }
            }
            #endregion

            return pieceCaptured;
        }
        public void UndoMove(Position origin, Position target, Piece pieceCaptured)
        {
            Piece p = Board.RemovePiece(target);
            p.DecreaseCountMoves();
            if (pieceCaptured != null)
            {
                Board.PlacePiece(p, origin);

                Captured.Remove(pieceCaptured);
            }
            Board.PlacePiece(p, origin);

            #region Undo Castling (Special Move)
            //Small Castling
            if (p is King && target.Column == origin.Column + 2)
            {
                Position rookOriginPosition = new Position(origin.Line, origin.Column + 3);
                Position rookTargetPosition = new Position(origin.Line, origin.Column + 1);
                Piece R = Board.RemovePiece(rookTargetPosition);
                R.DecreaseCountMoves();
                Board.PlacePiece(R, rookOriginPosition);
            }
            //Big Castling
            if (p is King && target.Column == origin.Column - 2)
            {
                Position rookOriginPosition = new Position(origin.Line, origin.Column - 4);
                Position rookTargetPosition = new Position(origin.Line, origin.Column - 1);
                Piece R = Board.RemovePiece(rookTargetPosition);
                R.DecreaseCountMoves();
                Board.PlacePiece(R, rookOriginPosition);
            }
            #endregion

            #region Undo En Passant
            if (p is Pawn)
            {
                if (origin.Column != target.Column && pieceCaptured == VulnerableToEnPassant)
                {
                    Piece pawn = Board.RemovePiece(target);
                    Position pawnPosition;
                    if (p.Color == Color.Red)
                    {
                        pawnPosition = new Position(3, target.Column);
                    }
                    else
                    {
                        pawnPosition = new Position(4, target.Column);
                    }
                    Board.PlacePiece(pawn, pawnPosition);
                }
            }
            #endregion
        }
        public void Play(Position origin, Position target) //"realizaJogada"
        {
            Piece pieceCaptured = ExecuteMove(origin, target);

            if (IsInCheck(CurrentPlayer) == true)
            {
                UndoMove(origin, target, pieceCaptured);
                throw new BoardException("You are not allowed to place yourself into check!");
            }

            Piece p = Board.Piece(target);
            #region PROMOTION (Special move)
            if (p is Pawn)
            {
                if ((p.Color == Color.Red && target.Line == 0) || (p.Color == Color.Yellow && target.Line == 7))
                {
                    p = Board.RemovePiece(target);
                    Pieces.Remove(p);

                    Piece queen = new Queen(Board, p.Color);
                    Board.PlacePiece(queen, target);
                    Pieces.Add(queen);               
                }

            }
            #endregion


            if (IsInCheck(Opponent(CurrentPlayer)) == true)
            {
                this.Check = true;
            }
            else
            {
                this.Check = false;
            }

            if (VerifyCheckMate(Opponent(CurrentPlayer)))
            {
                this.IsFinished = true;
            }
            else
            {
                this.Turn++;
                ChangePlayer();
            }

            #region EN PASSANT (Special Move)

            if (p is Pawn && (target.Line == origin.Line - 2 || target.Line == origin.Line + 2))
            {
                VulnerableToEnPassant = p;
            }
            else
            {
                VulnerableToEnPassant = null;
            }
            #endregion


        }
        public void ValidateOriginPosition(Position pos)
        {
            if (Board.Piece(pos) == null)
            {
                throw new BoardException("There's no Piece at the origin's position!");
            }

            if (CurrentPlayer != Board.Piece(pos).Color)
            {
                throw new BoardException("The chosen Piece does not belong to you!");
            }

            if (Board.Piece(pos).AreTherePossibleMoves() == false)
            {
                throw new BoardException("There are no possible moves for the chosen Piece!");
            }
        }
        public void ValidateTargetPosition(Position origin, Position target)
        {
            if (Board.Piece(origin).canMoveTo(target) == false)
            {
                throw new BoardException("Invalid target position!");
            }
        }
        private void ChangePlayer()
        {
            if (this.CurrentPlayer == Color.Red)
            {
                this.CurrentPlayer = Color.Yellow;
            }
            else
            {
                this.CurrentPlayer = Color.Red;
            }
        }
        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (var piece in Captured)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            return aux;
        }
        public HashSet<Piece> PiecesInPlay(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (var piece in Pieces)
            {
                if (piece.Color == color)
                {
                    aux.Add(piece);
                }
            }
            aux.ExceptWith(CapturedPieces(color));
            return aux;

        }
        private Color Opponent(Color color)
        {
            if (color == Color.Red)
            {
                return Color.Yellow;
            }
            else
            {
                return Color.Red;
            }
        }
        private Piece WhichKing(Color color)
        {
            foreach (var piece in PiecesInPlay(color))
            {
                if (piece is King)
                {
                    return piece;
                }
            }
            return null;
        }
        public bool IsInCheck(Color color)
        {
            var king = WhichKing(color);

            if (king == null)
            {
                throw new BoardException($"There is no {color} King on the board!");
            }

            foreach (var piece in PiecesInPlay(Opponent(color)))
            {
                bool[,] mat = piece.PossibleMoves();
                if ((mat[king.Position.Line, king.Position.Column]) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public bool VerifyCheckMate(Color color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }
            foreach (var x in PiecesInPlay(color))
            {
                bool[,] mat = x.PossibleMoves();
                for (int i = 0; i < Board.Lines; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (mat[i, j])
                        {

                            Position origin = x.Position;
                            Position target = new Position(i, j);
                            Piece slaughteredPiece = ExecuteMove(origin, target);
                            bool checkIFcheck = IsInCheck(color);
                            UndoMove(origin, target, slaughteredPiece);
                            if (!checkIFcheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void PlaceNewPiece(char column, int line, Piece piece)
        {
            Board.PlacePiece(piece, new ChessPosition(column, line).ConvertPosition());
            Pieces.Add(piece);
        }
        public void PlacePieces()
        {

            //Placing all red pieces for a new match. . .
            PlaceNewPiece('a', 3, new Rook(Board, Color.Red));
            PlaceNewPiece('b', 1, new Knight(Board, Color.Red));
            PlaceNewPiece('c', 1, new Bishop(Board, Color.Red));
            PlaceNewPiece('d', 1, new Queen(Board, Color.Red));
            PlaceNewPiece('e', 1, new King(Board, Color.Red, this));
            PlaceNewPiece('f', 1, new Bishop(Board, Color.Red));
            PlaceNewPiece('g', 1, new Knight(Board, Color.Red));
            PlaceNewPiece('h', 1, new Rook(Board, Color.Red));

            PlaceNewPiece('a', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('b', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('c', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('d', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('e', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('f', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('g', 2, new Pawn(Board, Color.Red, this));
            PlaceNewPiece('h', 2, new Pawn(Board, Color.Red, this));

            //Placing all yellow pieces for a new match...
            PlaceNewPiece('a', 8, new Rook(Board, Color.Yellow));
            PlaceNewPiece('b', 8, new Knight(Board, Color.Yellow));
            PlaceNewPiece('c', 8, new Bishop(Board, Color.Yellow));
            PlaceNewPiece('d', 8, new Queen(Board, Color.Yellow));
            PlaceNewPiece('e', 8, new King(Board, Color.Yellow, this));
            PlaceNewPiece('f', 8, new Bishop(Board, Color.Yellow));
            PlaceNewPiece('g', 8, new Knight(Board, Color.Yellow));
            PlaceNewPiece('h', 6, new Rook(Board, Color.Yellow));

            PlaceNewPiece('a', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('b', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('c', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('d', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('e', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('f', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('g', 7, new Pawn(Board, Color.Yellow, this));
            PlaceNewPiece('h', 7, new Pawn(Board, Color.Yellow, this));


            //Testing Check
            //PlaceNewPiece('c', 1, new Rook(Board, Color.Red));
            //PlaceNewPiece('c', 2, new Rook(Board, Color.Red));
            //PlaceNewPiece('d', 2, new Rook(Board, Color.Red));
            //PlaceNewPiece('e', 2, new Rook(Board, Color.Red));
            //PlaceNewPiece('e', 1, new Rook(Board, Color.Red));
            //PlaceNewPiece('d', 1, new King(Board, Color.Red));

            //PlaceNewPiece('c', 7, new Rook(Board, Color.Yellow));
            //PlaceNewPiece('c', 8, new Rook(Board, Color.Yellow));
            //PlaceNewPiece('d', 7, new Rook(Board, Color.Yellow));
            //PlaceNewPiece('e', 7, new Rook(Board, Color.Yellow));
            //PlaceNewPiece('e', 8, new Rook(Board, Color.Yellow));
            //PlaceNewPiece('d', 8, new King(Board, Color.Yellow));


            ////Testing CHECKMATE
            //PlaceNewPiece('c', 1, new Rook(Board, Color.Red));
            //PlaceNewPiece('d', 1, new King(Board, Color.Red));
            //PlaceNewPiece('h', 7, new Rook(Board, Color.Red));

            //PlaceNewPiece('a', 8, new King(Board, Color.Yellow));
            //PlaceNewPiece('b', 8, new Rook(Board, Color.Yellow));


            ////Testing the Knight            
            //PlaceNewPiece('d', 4, new Knight(Board, Color.Red));
            //PlaceNewPiece('a', 8, new Pawn(Board, Color.Yellow));


            ////Testing the Bishop            
            //PlaceNewPiece('d', 4, new Bishop(Board, Color.Red));
            //PlaceNewPiece('a', 8, new Pawn(Board, Color.Yellow));


            ////Testing the Queen
            //PlaceNewPiece('d', 4, new Queen(Board, Color.Red));
            //PlaceNewPiece('a', 8, new Pawn(Board, Color.Yellow));


            ////Testing the Pawns            
            //PlaceNewPiece('d', 2, new Pawn(Board, Color.Red));
            //PlaceNewPiece('e', 4, new Pawn(Board, Color.Red));
            //PlaceNewPiece('a', 1, new King(Board, Color.Red));
            //PlaceNewPiece('d', 5, new Pawn(Board, Color.Yellow));
            //PlaceNewPiece('h', 8, new King(Board, Color.Yellow));

        }
    }
}
