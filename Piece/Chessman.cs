using System;
using System.Linq;
using System.Collections.Generic;
using Utils;

namespace Piece
{
    public abstract class Chessman
    {
        protected readonly ChessColor Color;

        public bool IsTaken { get; private set; } = false;

        public Coordinate Position { get; private set; }

        public Chessman(ChessColor color, Coordinate initialPosition)
        {
            Color = color;
            Position = initialPosition;
        }

        // TODO: implement in all subclasses
        public abstract IEnumerable<Coordinate> GetAvailableMoves();

        public void Move(Coordinate target)
        {
            bool isMoveAllowed = GetAvailableMoves()
                .Contains(target);

            if (!isMoveAllowed)
            {
                throw new ArgumentException("Impossible move !");
            }

            Position = target;   
        }

        public void Take()
        {
            IsTaken = true;
            Position = Coordinate.OutOfBoard;
        }
    }
}
