using Piece;
using Utils;

namespace Game.Moves
{
    public class SimpleMove : Move
    {
        public SimpleMove(Coordinate target, GameState gameState, Chessman piece) 
            : base(target, gameState, piece) { }

        protected override void DoMoveIntermediarySteps() { }
    }
}
