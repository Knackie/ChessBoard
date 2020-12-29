using System.Collections.Generic;
using Board;
using Utils;
using Game;
using Game.Moves;

namespace Piece
{
    public class Rook : Chessman, IHasFirstMove
    {
        public bool IsFirstMove { get; set; } = true;

        public Rook(ChessColor color, Coordinate initialPosition)
            : base(color, initialPosition) { }

        private int MinXIndexOfLine(Chessboard board)
        {
            //we check for each case in a line the possible move
            for (int xMin = Position.X + 1; xMin < Chessboard.Dimension; xMin++)
            {
                var target = new Coordinate(xMin, Position.Y);

                var piece = board.GetCellFor(target).Piece;
                // if one on case is not empty
                if (!board.IsEmptyCell(target))
                {
                    //and if this cell had a enemy chessman on
                    if (piece?.Color != Color)
                    {
                        //we can take it
                        return xMin;
                    }
                    else
                    {
                        //if it's not enemy chess, we can't take 
                        return xMin - 1;
                    }
                }
            }
            return Chessboard.Dimension - 1;
        }

        private int MaxXIndexOfLine(Chessboard board)
        {
            for (int xMax = Position.X - 1; xMax >= 0; xMax--)
            {
                var target = new Coordinate(xMax, Position.Y);

                var piece = board.GetCellFor(target).Piece;

                if (!board.IsEmptyCell(target))
                {
                    if (piece?.Color != Color)
                    {
                        return xMax;
                    }
                    else
                    {
                        return xMax + 1;
                    }
                }
            }
            return 0;
        }

        private int MaxYIndexOfLine(Chessboard board)
        {
            for (int yMax = Position.Y + 1; yMax < Chessboard.Dimension; yMax++)
            {
                var target = new Coordinate(Position.X, yMax);

                var piece = board.GetCellFor(target).Piece;

                if (!board.IsEmptyCell(target))
                {
                    if (piece?.Color != Color)
                    {
                        return yMax;
                    }
                    else
                    {
                        return yMax - 1;
                    }
                }
            }
            return Chessboard.Dimension - 1;

        }

        private int MinYIndexOfLine(Chessboard board)
        {
            for (int yMin = Position.Y - 1; yMin >= 0; yMin--)
            {
                var target = new Coordinate(Position.X, yMin);

                var piece = board.GetCellFor(target).Piece;
                if (!board.IsEmptyCell(target))
                {
                    if (piece?.Color != Color)
                    {
                        return yMin;
                    }
                    else
                    {
                        return yMin + 1;
                    }
                }
            }
            return 0;
        }

        public override IEnumerable<Move> GetAvailableMoves(GameState gameState)
        {
            var board = gameState.Board;
            var moves = new List<Move>();

            var minY = MinYIndexOfLine(board);
            if (minY != Position.Y)
            {
                for (int i = 0; i > minY; i--)
                {
                    moves.Add(new SimpleMove(new(Position.X, i), gameState, this));
                }

            }
            var maxY = MaxYIndexOfLine(board);
            if (maxY != Position.Y)
            {
                for (int i = 0; i < maxY; i++)
                {
                    moves.Add(new SimpleMove(new(Position.X, i), gameState, this));
                }

            }
            var minX = MinXIndexOfLine(board);
            if (minX != Position.X)
            {
                for (int i = 0; i > minX; i--)
                {
                    moves.Add(new SimpleMove(new(i, Position.Y), gameState, this));
                }

            }
            var maxX = MaxXIndexOfLine(board);
            if (maxX != Position.X)
            {
                for (int i = 0; i < maxX; i--)
                {
                    moves.Add(new SimpleMove(new(i, Position.Y), gameState, this));
                }

            }

            // check from current position to max index if one piece for x to x max, x to x min, y to y min and y to y max
            //
            return new List<Move>();
        }

        public override string ToString()
            => $"R ({Color})";
    }
}
