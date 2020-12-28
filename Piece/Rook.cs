using System.Collections.Generic;
using Board;
using Utils;
using Game;

namespace Piece
{
    public class Rook : Chessman, IHasFirstMove
    {
        public bool IsFirstMove { get; set; } = true;

        public Rook(ChessColor color, Coordinate initialPosition)
            : base(color, initialPosition) { }

        private int MinXIndexOfLine( GameState gameState)
        {
            for (int i = Position.X + 1; i < Chessboard.Dimension; i++)
            {
                if (!gameState.Board.IsEmptyCell(new Coordinate(Position.X, i)))
                {
                    return i - 1;
                }

            }
            return Chessboard.Dimension - 1;
        }

        private int MaxXIndexOfLine( GameState gameState)
        {
            for (int i = Position.X - 1; i >= 0; i--)
            {
                if (!gameState.Board.IsEmptyCell(new Coordinate(i, Position.Y)))
                {
                    return i + 1;
                }

            }
            return 0;
        }

        private int MaxYIndexOfLine(GameState gameState)
        {
            for (int i = Position.Y + 1; i < Chessboard.Dimension; i++)
            {
                if (!gameState.Board.IsEmptyCell(new Coordinate(Position.X, i)))
                {
                    return i - 1;
                }

            }
            return Chessboard.Dimension - 1;

        }

        private int MinYIndexOfLine(GameState gameState)
        {
            for (int i = Position.Y-1; i >= 0; i--)
            {
                if (!gameState.Board.IsEmptyCell(new Coordinate(Position.X, i)))
                {
                    return i + 1;
                }
                
            }
            return 0;
        }

        public override IEnumerable<Move> GetAvailableMoves(GameState gameState)
        {
            /*
            var moves = new List<Move>();

            var minY = MinYIndexOfLine(gameState);
            if (minY != Position.Y)
            {
                for (int i = 0; i > minY; i--)
                {
                    moves.Add(new (Position.X, i));
                }

            }
            var maxY = MinYIndexOfLine(gameState);
            if (maxY != Position.Y)
            {
                for (int i = 0; i < maxY; i++)
                {
                    moves.Add(new(Position.X, i));
                }

            }
            var minX = MinYIndexOfLine(gameState);
            if (minX != Position.Y)
            {
                for (int i = 0; i > minX; i--)
                {
                    moves.Add(new(i, Position.Y));
                }

            }
            var maxX = MinYIndexOfLine(gameState);
            if (maxX != Position.Y)
            {
                for (int i = 0; i < maxX; i--)
                {
                    moves.Add(new( i, Position.Y));
                }

            }

            // check from current position to max index if one piece for x to x max, x to x min, y to y min and y to y max
            */
            return new List<Move>();
        }

        public override string ToString()
             => $"R ({Color})";
    }
}
