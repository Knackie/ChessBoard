using Piece;
using Utils;

namespace Game.Moves
{
	public abstract class Move
	{
		public readonly Coordinate Target;

		protected readonly GameState GameState;

		protected readonly Chessman Piece;

		protected Move(Coordinate target, GameState gameState, Chessman piece)
		{
			GameState = gameState;
			Target = target;
			Piece = piece;
		}

		public void DoMove()
		{
			var currentPieceCell = GameState.Board.GetCellFor(Piece.Position);
			var targetCell = GameState.Board.GetCellFor(Target);

			DoMoveIntermediarySteps();

			currentPieceCell.MoveContentTo(targetCell);
		}

		protected abstract void DoMoveIntermediarySteps();
	}
}
