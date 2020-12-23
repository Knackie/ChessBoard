using System.Drawing;
using System;
using System.Collections.Generic;
using Utils;

namespace Piece
{
    public class Pawn : Chessman
    {
        public Pawn(ChessColor color, Coordinate initialPosition)
            : base(color, initialPosition) { }

        // TODO: check if possible according to Chessboard.Dimension
        public override IEnumerable<Coordinate> GetAvailableMoves()
        {
            var move = Color == ChessColor.White
                ? new Coordinate(Position.X, Position.Y + 1)
                : new Coordinate(Position.X, Position.Y - 1);

            return new[] { move };
        }
    }
}
