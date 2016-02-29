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

        public Game()
        {
            _board = new Board();
        }

        public void Reset()
        {
            _board.Initialize();
        }

        public void Run()
        {
            // TODO add the games main loop here
        }
    }
}
