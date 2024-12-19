using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boards;
using Chess;
using Microsoft.Win32.SafeHandles;

namespace xadrez_console
{
    public class Screen
    {

        public static void ShowMatch(ChessMatch match)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();

            DisplayBoard(match.Board);
            Console.WriteLine();
            ShowCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"\nTurn: {match.Turn}");
            Console.WriteLine($"Waiting for {match.CurrentPlayer} Player to play");
            if(match.Check == true)
            {
                Console.WriteLine($"{match.CurrentPlayer} Player is in CHECK!");
            }
        }

        public static void ShowCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces: ");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"Red Player ({match.CapturedPieces(Color.Yellow).Count}): ");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            PrintGrouping(match.CapturedPieces(Color.Yellow));
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("]");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"Yellow Player ({match.CapturedPieces(Color.Red).Count}): ");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            PrintGrouping(match.CapturedPieces(Color.Red));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("]");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void PrintGrouping(HashSet<Piece> grouping)
        {
            Console.Write($"{String.Join(",", grouping)}");
        }

        public static void DisplayBoard(Board board)
        {

            for (int i = 0; i < board.Lines; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($"{8 - i}  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    printPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
        }

        public static void DisplayBoard(Board board, bool[,] possibleMoves, Position pos)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i}  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j] == true)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    if (pos.Line == i && pos.Column == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    printPiece(board.Piece(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
            }
            Console.WriteLine("   a b c d e f g h");
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.Red)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"{piece}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{piece}");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.Write(" ");
            }
        }
    }
}
