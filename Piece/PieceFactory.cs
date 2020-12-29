using Piece;
using Utils;
using Board;
using System;
using System.Collections.Generic;

namespace Piece
{
    public static class PieceFactory
    {
        private static readonly Coordinate DefaultCoordinate = new Coordinate(0, 0);

        private static List<Pawn> CreateRowOfPawns(ChessColor color)
        {
            var pawns = new List<Pawn>();

            for (int i = 0; i < Chessboard.Dimension; i++)
            {
                pawns.Add(new Pawn(color, DefaultCoordinate));
            }

            return pawns;
        }
        public static List<Chessman> CreateWhitePiecesSet()
        {
            var color = ChessColor.White;
            var value = new List<Chessman>();
            value.AddRange(CreateRowOfPawns(color));

            value.Add(new Rook(color, DefaultCoordinate));

            for (int i = 0; i < 6; i++)
            {
                // TODO : create and add other pieces !
                value.Add(new Pawn(color, DefaultCoordinate));
            }

            value.Add(new Rook(color, DefaultCoordinate));

            return value;
        }

        public static List<Chessman> CreateBlackPiecesSet()
        {
            var color = ChessColor.Black;
            var value = new List<Chessman>();

            value.Add(new Rook(color, DefaultCoordinate));

            for (int i = 0; i < 6; i++)
            {
                // TODO : create and add other pieces !
                value.Add(new Pawn(color, DefaultCoordinate));
            }

            value.Add(new Rook(color, DefaultCoordinate));

            value.AddRange(CreateRowOfPawns(color));

            return value;
        }

        public static List<Chessman> CreatePiecesSet(ChessColor color)
            => color switch
            {
                ChessColor.White => CreateWhitePiecesSet(),
                ChessColor.Black => CreateBlackPiecesSet(),
                _ => throw new ArgumentException("Bad color"),
            };
    }
}
