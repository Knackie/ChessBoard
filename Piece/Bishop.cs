using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using Game.Moves;
using Piece;
using Utils;

namespace Piece
{
    class Bishop : Chessman
    {
        public Bishop(ChessColor color, Coordinate initialPosition) : base(color, initialPosition)
        {
        }

        public override IEnumerable<Move> GetAvailableMoves(GameState gameState)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
