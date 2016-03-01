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

        public int Width => 40;
        public int Height => 10;

        public Board()
        {
            _board = new int[Width, Height];
            Initialize();
        }

        public void Initialize()
        {
            for (int y = 0; y < _board.GetLength(1); y++)
            {
                for (int x = 0; x < _board.GetLength(0); x++)
                {
                    _board[x, y] = 0;
                }
            }
        }

        public int GetStateAt(int x, int y)
        {
            return _board[x, y];
        }

        public void DrawBoard()
        {
            for (int y = 0; y < _board.GetLength(1); y++)
            {
                for (int x = 0; x < _board.GetLength(0); x++)
                {
                    Console.Write(_board[x, y]);
                }
                Console.Write("\n");
            }
        }
    }
}
