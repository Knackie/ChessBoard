using System.Collections.Generic;
using Piece;
using System.Linq;
using Utils;

namespace Player
{
    public abstract class ChessPlayer
    {
        public readonly ChessColor Color;

        public readonly List<Chessman> Pieces;

        // TODO: add all conditions (checkmate, etc.)
        public bool IsStuck
            => Pieces.Select(piece => piece.GetAvailableMoves())
                .Any();

        public ChessPlayer(ChessColor color, List<Chessman> pieces)
        {
            Color = color;

            Pieces = pieces;    
        }

        // TODO: player move in child classes
        public abstract void Play(/* ??? */);
    }
}
