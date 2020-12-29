using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Piece;
using Utils;

namespace Game.Moves
{
    class TwoCellsMove : Move
    {
        public TwoCellsMove(Coordinate target, GameState gameState, Chessman piece)
            : base(target, gameState, piece) { }

        protected override void DoMoveIntermediarySteps()
        {
            if (Piece is Pawn pawn)
            {
                pawn.HasMovedFromTwoCells = true;
            }
        }
    }
}
