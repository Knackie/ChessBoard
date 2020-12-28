using System.Collections.Generic;
using Board;
using Game;
using Utils;

namespace Piece
{
    public class Pawn : Chessman, IHasFirstMove
    {
        public Pawn(ChessColor color, Coordinate initialPosition)
            : base(color, initialPosition) { }

        public bool IsFirstMove { get; set; } = true;

        public bool IsDiagonalValid(Coordinate diagonalCoordinate, GameState gameState)
        {
            var diagonalCellColor = gameState.Board
               .GetCellFor(diagonalCoordinate)
               .Color;

            var isDiagonalCellEatable = diagonalCellColor != Color
                && diagonalCellColor != null;

            return Chessboard.IsInBoard(diagonalCoordinate)
               && isDiagonalCellEatable;
        }

        public override IEnumerable<Move> GetAvailableMoves(GameState gameState)
        {
            var moves = new List<Move>();

            // Standard move : move of one cell in front of the pawn
            var nextCellInFront = new Coordinate(Position.X, Position.Y + 1);

            if (Chessboard.IsInBoard(nextCellInFront)
                && gameState.Board.IsEmptyCell(nextCellInFront))
            {
                moves.Add(nextCellInFront);
            }

            // Special move : go two cell in front of the pawn if it's the first move
            var secondNextCellInFront = new Coordinate(Position.X, Position.Y + 2);

            if (IsFirstMove 
                && gameState.Board.IsEmptyCell(secondNextCellInFront)
                && Chessboard.IsInBoard(secondNextCellInFront))
            {
                moves.Add(secondNextCellInFront);
            }

            // Eating in diagonal 
            var upRightCellInFront = new Coordinate(Position.X + 1, Position.Y + 1);
            if (IsDiagonalValid(upRightCellInFront, gameState))
            {
                moves.Add(upRightCellInFront);
            }

            var upLeftCellInFront = new Coordinate(Position.X - 1, Position.Y + 1);
            if (IsDiagonalValid(upLeftCellInFront, gameState))
            {
                moves.Add(upLeftCellInFront);
            }

            return moves;
        }

        public override string ToString()
            => $"P ({Color})";
    }
}
