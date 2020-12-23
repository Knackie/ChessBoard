using System.Collections.Generic;
using Piece;
using Utils;

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

            for (var i = 0; i < Dimension; ++i)
            {
                for (var j = 0; j < Dimension; ++j)
                {
                    Board[i, j] = new ChessCell(new Coordinate(i, j));
                }
            }

            // TODO: Set up the pieces
        }

        public Chessboard Copy()
            => new Chessboard(Board);

        public ChessCell GetCellFor(Coordinate coordinate)
            => Board[coordinate.X, coordinate.Y];
    }
}
