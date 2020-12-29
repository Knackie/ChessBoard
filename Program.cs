using System;
using Game;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new GameState();

            Console.WriteLine("Game created");

            Console.Write(game.ToString());

            game.Play();

            while (!game.IsGameOver)
            {
                Console.WriteLine("--- Player move ---");
               
            }
            

            Console.WriteLine("Game has ended !");
        }
    }
}
