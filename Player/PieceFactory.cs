using Piece;
using Utils;
using System.Collections.Generic;

public static class PieceFactory
{
	private static readonly Coordinate DefaultCoordinate = new Coordinate(0, 0);

	private const int NumberPiece = 16;

	public static List<Chessman> CreatePiecesSet(ChessColor color)
	{
		var value = new List<Chessman>();

		for (int i = 0; i < NumberPiece; i++)
        {
            value.Add(new Pawn(color, DefaultCoordinate));
        }

		return value;
	}
}
