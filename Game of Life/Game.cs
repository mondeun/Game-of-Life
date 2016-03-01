using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Game
    {
        private Board _board;
        private int _generation;

        public Game()
        {
            _board = new Board();
            _generation = 0;
        }

        public void Reset()
        {
            _board.Initialize();
            _generation = 0;
        }

        public void Run()
        {
            // TODO add the games main loop here
            bool run = true;

            while (run)
            {
                Console.Clear();

                _board.DrawBoard();

                Console.ReadKey();
            }
        }
    }
}
