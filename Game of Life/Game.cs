using System;
using System.Threading;

namespace Game_of_Life
{
    class Game
    {
        private Board _board;
        private int _frame;

        public Game()
        {
            _board = new Board();
            _frame = 1;
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

                _board.Update();

                Console.WriteLine($"Frame: {_frame} : Width: {_board.Width} : Height: {_board.Height}\n");
                _board.Draw();


                if (auto)
                    Thread.Sleep(250);
                else
                    Console.ReadKey();
                _frame++;
            }
        }
    }
}
