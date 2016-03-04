using System;
using System.Threading;

namespace Game_of_Life
{
    class Game
    {
        private Generation _generation;

        public Game()
        {
            _generation = new Generation();
        }

        /// <summary>
        /// The game loop which updates and draw the game
        /// </summary>
        /// <param name="auto">If to set next frame automatically or not</param>
        public void Run(bool auto)
        {
            while (true)
            {
                Console.Clear();

                _generation.Update();

                Console.WriteLine($"Tick: {_generation.Tick} : Width: {_generation.Width} : Height: {_generation.Height}\n");
                _generation.Draw();


                if (auto)
                    Thread.Sleep(250);
                else
                    Console.ReadKey();
            }
        }
    }
}
