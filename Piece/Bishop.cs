using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Board;
using Game;
using Game.Moves;
using Piece;
using Utils;

namespace Piece
{
    class Bishop : Chessman
    {
        public Bishop(ChessColor color, Coordinate initialPosition) 
            : base(color, initialPosition) { }

        private Coordinate MaxDiagonalUpRight(Chessboard board)
        {
            int maxX = Position.X - 1;
            int maxY = Position.Y + 1;
            do
            {
                var target = new Coordinate(maxX, maxY);

                var piece = board.GetCellFor(target).Piece;

                if (!board.IsEmptyCell(target))
                {
                    if (piece?.Color != Color)
                    {
                        return target;
                    }
                    else
                    {
                        return new(target.X - 1, target.Y - 1);
                    }
                }
            }
            while (maxY < Chessboard.Dimension && maxX > 0);

            return new (maxX,maxY);
        }
        public override IEnumerable<Move> GetAvailableMoves(GameState gameState)
        {
            var moves = new List<Move>();
            var board = gameState.Board;

            var maxDiagUpRight = MaxDiagonalUpRight(board);
            if (maxDiagUpRight != Position)
            {
                for (int i = Position.Y; i < maxDiagUpRight.Y; i++)
                {
                    moves.Add(new SimpleMove(new(Position.X - i, Position.Y + i), gameState, this));
                }

            }
            return moves;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
