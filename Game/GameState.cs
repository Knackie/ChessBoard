using System.Collections.Generic;
using System;
using Player;
using Piece;
using Utils;
using Board;

namespace Game
{
	public class GameState
	{
		private const int HistorySize = 5;

		public readonly ChessPlayer Black;

		public readonly Chessboard Board;

		public readonly ChessPlayer White;

		public readonly Stack<GameState> History;

		public bool IsGameOver
			=> Black.IsStuck(this)
			|| White.IsStuck(this);

		private GameState(ChessPlayer black, Chessboard board, ChessPlayer white)
			=> (Black, Board, White, History)
			= (black, board, white, new Stack<GameState>(HistorySize));

		public GameState()
		{
			// TODO: create the player's classes
			Black = new HumanPlayer(ChessColor.Black, PieceFactory.CreatePiecesSet(ChessColor.Black));
			White = new HumanPlayer(ChessColor.White, PieceFactory.CreatePiecesSet(ChessColor.White));

			// Create the board for the players
			Board = new Chessboard(Black.Pieces, White.Pieces);

			// Create and initialize the history
			History = new Stack<GameState>(HistorySize);
			History.Push(this.Copy());
		}

		public GameState Copy()
			=> new GameState(Black, Board, White);

		public void Play()
		{
			if (IsGameOver)
			{
				throw new ArgumentException("The game is over and no move can be performed !");
			}

			// Usage example:
			//
			// var piece = White.Pieces[0];
			//
			// var move = piece.GetAvailableMoves()
			//     .FirstOrDefault();
			//
			// var currentPieceCell = Board.GetCellFor(piece.Position);
			// var targetCell = Board.GetCellFor(move);
			//
			// currentPieceCell.MoveContentTo(targetCell);

			// TODO: Retrieve the player currently playing

			// TODO: Make a move

			// TODO: Toggle the playing player

			// Add to history the played move
			History.Push(this.Copy());

			throw new NotImplementedException();
		}

		public override string ToString()
			=> Board.ToString();
	}
}
