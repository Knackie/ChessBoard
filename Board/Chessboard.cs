using System.Collections.Generic;
using Piece;
using Utils;
using System.Linq;

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

            var remainingBlackPieces = new Stack<Chessman>(blackPieces);
            var remainingWhitePieces = new Stack<Chessman>(whitePieces);

            for (int row = 0; row < Dimension; ++row)
            {
                for (int column = 0; column < Dimension; ++column)
                {
                    var currentCoordinate = new Coordinate(row, column);
                    Board[row, column] = InitializePieceAtCoordinate(currentCoordinate, remainingBlackPieces, remainingWhitePieces);
                }
            }
        }

        private static ChessCell InitializePieceAtCoordinate(Coordinate coordinate, Stack<Chessman> remainingBlackPieces, Stack<Chessman> remainingWhitePieces)
        {
            var rowsForPieces = 2;

            var blackPiecesColumnRange = Enumerable.Range(0, rowsForPieces);
            var whitePiecesColumnRange = Enumerable.Range(Dimension - rowsForPieces, Dimension);

            var currentColumn = coordinate.X;

            if (whitePiecesColumnRange.Contains(currentColumn))
            {
                return new ChessCell(coordinate, remainingWhitePieces.Pop());
            }

            if (blackPiecesColumnRange.Contains(currentColumn))
            {
                return new ChessCell(coordinate, remainingBlackPieces.Pop());
            }

            return new ChessCell(coordinate);
        }

        public override string ToString()
        {
            var toString = string.Empty;

            for (int i = 0; i < Dimension; i++)
            {
                toString += "|";
                for (int j = 0; j < Dimension; j++)
                {
                    toString += Board[i, j].ToString();
                }
                toString += "\n";
            }

            return toString;

        }

        public bool IsEmptyCell(Coordinate target)
        {
            return !GetCellFor(target).HasPiece;
        }

        public static bool IsInBoard(Coordinate coordinateToCheck)
        {
            return coordinateToCheck.Y < Dimension
                && coordinateToCheck.Y >= 0
                && coordinateToCheck.X < Dimension
                && coordinateToCheck.X >= 0;
        }

        public Chessboard Copy()
            => new Chessboard(Board);

        public ChessCell GetCellFor(Coordinate coordinate)
            => Board[coordinate.X, coordinate.Y];
    }
}
