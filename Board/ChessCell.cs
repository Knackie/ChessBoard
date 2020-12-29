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

        public ChessColor? Color
            => Piece?.Color;

        public ChessCell(Coordinate coordinate, Chessman? NewPiece = null)
        {
            Coordinate = coordinate;
            Piece = NewPiece;
            if (Piece != null)
            {
                Piece.Position = coordinate;
            }
        }

        public void MoveContentTo(ChessCell target)
        {
            if (!HasPiece)
            {
                throw new ArgumentException("No piece on this chess cell !");
            }

            // target.SetPiece(Piece!);
            target.SetPiece(new Rook(Piece!.Color, Coordinate));

            Piece = null;
        }

        private void UpgradeToQueen()
        {
            if (!(Piece is Pawn))
            {
                return;
            }

            switch (Piece.Color)
            {
                case ChessColor.Black:
                    if (Piece.Position.Y == Chessboard.Dimension - 1)
                    {
                        UpgradeToBlackQueen();
                    }
                    break;
                case ChessColor.White:
                    if (Piece.Position.Y == 0)
                    {
                        UpgradeToWhiteQueen();
                    }
                    break;
                default:
                    break;
            }
        }

        private void UpgradeToBlackQueen()
        {
            //TODO : implemente the black upgrade
            throw new NotImplementedException();
        }

        private void UpgradeToWhiteQueen()
        {
            //TODO : implemente the white upgrade
            throw new NotImplementedException();
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
            Piece.Position = Coordinate;
        }
    }
}
