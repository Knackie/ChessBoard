using System.Collections.Generic;
using Board;
using Game;
using Game.Moves;
using Utils;

namespace Piece
{
    public class Pawn : Chessman, IHasFirstMove
    {
        public bool HasMovedFromTwoCells { get; set; } = false;

        public Pawn(ChessColor color, Coordinate initialPosition)
            : base(color, initialPosition) { }

        public bool IsFirstMove { get; set; } = true;

        public bool IsEnPassantValid(Coordinate toCheck, Coordinate target, GameState gameState)
        {
            // if the cell to check is not empty
            return !gameState.Board.IsEmptyCell(toCheck)
                // and if the cell contains a pawn
                && gameState.Board.GetCellFor(toCheck).Piece is Pawn pawn
                // and it's enemy pawn
                && pawn.Color != Color
                // and has move from 2 cells
                && pawn.HasMovedFromTwoCells
                // and if the pawn had only one move
                && pawn.MoveCount == 1
                // and is the target cell is empty to make the "en passant" move
                && gameState.Board.IsEmptyCell(target);
        }

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
            Coordinate nextCellInFront;
            Coordinate secondNextCellInFront;
            Coordinate upRightCellInFront;
            Coordinate upLeftCellInFront; 
            var enPassantLeft = new Coordinate(Position.X, Position.Y - 1); 
            Coordinate enPassantRight = new Coordinate(Position.X, Position.Y + 1); ;




            // Standard move : move of one cell in front of the pawn
            if (Color == ChessColor.White)
            {
                nextCellInFront = new Coordinate(Position.X - 1, Position.Y);
                secondNextCellInFront = new Coordinate(Position.X - 2, Position.Y);
                upRightCellInFront = new Coordinate(Position.X - 1, Position.Y + 1);
                upLeftCellInFront = new Coordinate(Position.X - 1, Position.Y + 1);

            }
            else 
            {
                secondNextCellInFront = new Coordinate(Position.X + 2, Position.Y);
                nextCellInFront = new Coordinate(Position.X + 1, Position.Y);
                upRightCellInFront = new Coordinate(Position.X + 1, Position.Y + 1);
                upLeftCellInFront = new Coordinate(Position.X + 1, Position.Y + 1);


            }
            // Standard move : move of one cell in front of the pawn

            if (Chessboard.IsInBoard(nextCellInFront)
                    && gameState.Board.IsEmptyCell(nextCellInFront))
            {
                moves.Add(new SimpleMove(nextCellInFront, gameState, this));
            }

            // Special move : go two cell in front of the pawn if it's the first move

            if (IsFirstMove
                    && gameState.Board.IsEmptyCell(secondNextCellInFront)
                    && Chessboard.IsInBoard(secondNextCellInFront)
                    && Chessboard.IsInBoard(nextCellInFront))
            {
                moves.Add(new TwoCellsMove(secondNextCellInFront, gameState, this));
            }

            // Eating in diagonal
            if (IsDiagonalValid(upRightCellInFront, gameState))
            {
                moves.Add(new SimpleMove(upRightCellInFront, gameState, this));
            }

            if (IsDiagonalValid(upLeftCellInFront, gameState))
            {
                moves.Add(new SimpleMove(upLeftCellInFront, gameState, this));
            }

            // En Passant Left

            if (IsEnPassantValid(enPassantLeft, upLeftCellInFront, gameState))
            {
                moves.Add(new EnPassant(upLeftCellInFront, gameState, this));
            }

            // En Passant Left

            if (IsEnPassantValid(enPassantRight, upRightCellInFront, gameState))
            {
                moves.Add(new EnPassant(upRightCellInFront, gameState, this));
            }



            // En Passant Right
            return moves;
        }
       
        public override string ToString()
            => $"P ({Color})";
    }
}
