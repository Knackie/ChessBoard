using Piece;
using Utils;

namespace Game.Moves
{
    public class EnPassant : Move
    {
        public EnPassant(Coordinate target, GameState gameState, Chessman Piece) 
            : base(target, gameState, Piece) { }

        protected override void DoMoveIntermediarySteps()
        {
            var chessCell = GameState.Board.GetCellFor(new(Piece.Position.X + 1, Piece.Position.Y));
                    //TODO : eating the next case

            if (Piece.Color == ChessColor.White)
            {
               
            }
            if (Piece.Color == ChessColor.Black)
            {
                var eatCell = GameState.Board.GetCellFor(new(Piece.Position.X + 1, Piece.Position.Y));
            }
        }
    }
}
