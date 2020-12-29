using System;
using System.Linq;
using System.Collections.Generic;
using Utils;
using Game;
using Game.Moves;

namespace Piece
{
    public abstract class Chessman
    {
        public int MoveCount { get; private set; } = 0;

        public readonly ChessColor Color;

        public bool IsTaken { get; private set; } = false;

        public Coordinate Position { get; set; }

        public Chessman(ChessColor color, Coordinate initialPosition)
        {
            Color = color;
            Position = initialPosition;
        }

        // TODO: implement in all subclasses
        public abstract IEnumerable<Move> GetAvailableMoves(GameState gameState);

        public void Move(Coordinate target, GameState gameState)
        {
            //TODO : make the method
            /*    bool isMoveAllowed = GetAvailableMoves(gameState)
					.Contains(target);

					if (!isMoveAllowed)
					{
					throw new ArgumentException("Impossible move !");
					}

					Position = target;   */
            ++MoveCount;
        }

        public void Take()
        {
            IsTaken = true;
            Position = Coordinate.OutOfBoard;
        }

        public abstract override string ToString();

    }
}
