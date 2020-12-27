using System.Collections.Generic;
using Piece;
using Utils;
using System;

namespace Board
{
    public class Chessboard
    {
        public const int Dimension = 8;

        public readonly ChessCell[,] Board;

        private Chessboard(ChessCell[,] board)
            => Board = board;

        public Chessboard(List<Chessman> blackPieces, List<Chessman> whitePieces) 
        {
            // Initialize the board
            Board = new ChessCell[Dimension, Dimension];

            // Fill the board without piece
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    var currentCoordinate = new Coordinate(i, j);
                    Board[i, j] = new ChessCell(currentCoordinate);
                }
            }
            
            const int rowsForPieces = 2;
            
            var remainingWhitePieces = new Stack<Chessman>(whitePieces);
            var remainingBlackPieces = new Stack<Chessman>(blackPieces);

            // Initialize Black pieces at the top of the board
            for (int i = 0; i < rowsForPieces; ++i)
            {
                for (int j = 0; j < Dimension; ++j)
                {
                    var currentCoordinate = new Coordinate(i, j);
                    Board[i, j] = new ChessCell(currentCoordinate, remainingBlackPieces.Pop());
                }
            }

            // Initialize White pieces at the end of the board
            for (int i = Dimension - 1; i > Dimension - rowsForPieces - 1; --i)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    var currentCoordinate = new Coordinate(i, j);
                    Board[i, j] = new ChessCell(currentCoordinate, remainingWhitePieces.Pop());
                }
            }
        }

        public override string ToString()
        {
            var toString = string.Empty;

            for (int i = 0; i < Dimension; i++)
            {
                toString += "|";
                for (int j =0; j < Dimension; j++)
                {
                    toString += Board[i, j].ToString();
                }
                toString += "\n";
            }

            return toString;
            
        }

        public Chessboard Copy()
            => new Chessboard(Board);

        public ChessCell GetCellFor(Coordinate coordinate)
            => Board[coordinate.X, coordinate.Y];
    }
}
