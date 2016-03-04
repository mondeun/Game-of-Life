using System;

namespace Game_of_Life
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "GAME OF LIFE";
            Console.WriteLine("Run game in AUTO mode? (y/n)");
            var choice = Console.ReadKey(true);
            var game = new Game();
            game.Run(choice.Key == ConsoleKey.Y);
        }
    }
}
