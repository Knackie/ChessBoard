using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using Board;

namespace Piece
{
    public abstract class Chessman
    {
        public readonly ChessColor Color;

        public bool IsTaken { get; private set; } = false;

        public Coordinate Position { get; set; }

        public Chessman(ChessColor color, Coordinate initialPosition)
        {
            Color = color;
            Position = initialPosition;
        }

        // TODO: implement in all subclasses
        public abstract IEnumerable<Coordinate> GetAvailableMoves(GameState gameState);
        
        public void Move(Coordinate target, GameState gameState)
        {
            bool isMoveAllowed = GetAvailableMoves(gameState)
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

        public abstract override string ToString();

    }
}
