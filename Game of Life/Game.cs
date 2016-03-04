using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Game
    {
        private Board _board;
        private int _frame;

        public Game()
        {
            _board = new Board();
            _frame = 0;
        }

        /// <summary>
        /// Update and draw the game
        /// </summary>
        public void Run()
        {
            bool run = true;

            while (run)
            {
                Console.Clear();

                _board.Update();

                Console.WriteLine($"Frame: {_frame} : Width: {_board.Width} : Height: {_board.Height}\n");
                _board.Draw();

                //Console.ReadKey();
                Thread.Sleep(250);
                _frame++;
            }
        }
    }
}
