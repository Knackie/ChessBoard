using System;
using Board;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState();
            Console.WriteLine("Game created");

            while (!game.IsGameOver)
            {
                Console.WriteLine("--- Player move ---");
                game.Play();
            }

            Console.WriteLine("Game has ended !");
        }
    }
}
