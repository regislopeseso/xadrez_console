using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boards;
using Chess;

namespace xadrez_console
{
    public class Screen
    {

        public static void DisplayBoard(Board board)
        {
            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i}  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    printPiece(board.Piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
        }

        public static void DisplayBoard(Board board, bool[,] possibleMoves)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor changedColor = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Lines; i++)
            {
                Console.Write($"{8 - i}  ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMoves[i, j] == true)
                    {
                        Console.BackgroundColor = changedColor;
                    }
                    else 
                    {
                        Console.BackgroundColor = originalColor;
                    }
                    printPiece(board.Piece(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("   a b c d e f g h");
            Console.BackgroundColor = originalColor;
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

                if (piece.Color == Color.White)
                {
                    Console.Write($"{piece}");
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{piece}");
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }       
    }
}
