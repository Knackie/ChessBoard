using System;
using Board;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState();

            Console.WriteLine("Game created");

            Console.Write(game.ToString());

            while (!game.IsGameOver)
            {
                Console.WriteLine("--- Player move ---");
                game.Play();
            }
            

            Console.WriteLine("Game has ended !");
        }
    }
}
