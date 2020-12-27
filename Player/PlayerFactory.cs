using Piece;
using Utils;

namespace Player
{
    public static class PlayerFactory
    {
        public static ChessPlayer CreateHumanPlayer(ChessColor color)
            => new HumanPlayer(color, PieceFactory.CreatePiecesSet(color));
    }
}