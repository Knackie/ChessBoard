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
            int BlackCount=0, WhiteCount = 0;
            for (var i = 0; i < Dimension; i++)
            {
                for (var j = 0; j < Dimension; j++)
                {
                    var currentCoordinate = new Coordinate(i, j);
                    
                    if ( i < 2)
                    {
                        Board[i, j] = new ChessCell(currentCoordinate, blackPieces[BlackCount++]);
                    }
                    if (i > 5)
                    {
                        Board[i, j] = new ChessCell(currentCoordinate, whitePieces[WhiteCount++]);
                        //Board[i, j] = new ChessCell(currentCoordinate, blackPieces[BlackCount++]);
                    }
                    else
                    {
                        Board[i, j] = new ChessCell(currentCoordinate);

                    }

                    
                }
            }
           
        }
        public string Print()
        {
            string value = "";
            for (int i = 0; i < Dimension; i++)
            {
                for (int j =0; j < Dimension; j++)
                {
                    value +=Board[i, j].Print();
                }
                value += "\n";
            }
            return value;
            
        }

        public Chessboard Copy()
            => new Chessboard(Board);

        public ChessCell GetCellFor(Coordinate coordinate)
            => Board[coordinate.X, coordinate.Y];
    }
}
