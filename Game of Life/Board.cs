using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Board
    {
        private int[,] _board;

        public static int Size => 100;

        public Board()
        {
            _board = new int[Size,Size];
            Initialize();
        }

        public void Initialize()
        {
            for (int x = 0; x < _board.GetLength(0); x++)
            {
                for (int y = 0; y < _board.GetLength(1); y++)
                {
                    _board[x, y] = 0;
                }
            }
        }

        public int GetStateAt(int x, int y)
        {
            return _board[x, y];
        }
    }
}
