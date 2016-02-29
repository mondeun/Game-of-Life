using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Board
    {
        public const int Size = 100;
        private int[,] _board;

        public Board()
        {
            _board = new int[Size,Size];
        }
    }
}
