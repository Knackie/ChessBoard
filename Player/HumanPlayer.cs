using System.Collections.Generic;
using Piece;
using Utils;

namespace Player
{
    public class HumanPlayer : ChessPlayer
    {
        public HumanPlayer(ChessColor color, List<Chessman> pieces)
            : base(color, pieces) { }

        public override void Play()
        {
            // TODO: human move
            throw new System.NotImplementedException();
        }
    }
}
