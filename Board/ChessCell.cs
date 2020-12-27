using System;
using Piece;
using Utils;

namespace Board
{
    public class ChessCell
    {
        public readonly Coordinate Coordinate;

        public Chessman? Piece { get; private set; } = null;

        public bool HasPiece
            => Piece != null;

        public ChessCell(Coordinate coordinate, Chessman? NewPiece = null)
        {
            Coordinate = coordinate;
            Piece = NewPiece;
            if (Piece == null)
            {
                return;
            }
            Piece.Position = coordinate;
        }

        public void MoveContentTo(ChessCell target)
        {
            if (!HasPiece)
            {
                throw new ArgumentException("No piece on this chess cell !");
            }

            target.SetPiece(Piece!);

            Piece = null;
        }

        public override string ToString()
            => $"{Piece?.ToString() ?? " *Empty* "}|";

        private void SetPiece(Chessman incomingPiece)
        {
            if (HasPiece)
            {
                Piece!.Take();
            }

            Piece = incomingPiece;
        }
    }
}