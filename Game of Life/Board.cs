using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Life
{
    class Board
    {
        public enum State
        {
            Dead = 0,
            Alive = 1
        };

        private State[,] _board;
        private Random _rand;

        public int Width => 40;
        public int Height => 20;

        public Board()
        {
            _board = new State[Width, Height];
            _rand = new Random();
            Initialize();
        }

        public void Initialize()
        {
            for (int y = 0; y < _board.GetLength(1); y++)
            {
                for (int x = 0; x < _board.GetLength(0); x++)
                {
                    int tmp = _rand.Next(0, 2);
                    if(tmp == 0)
                        _board[x, y] = State.Dead;
                    else
                        _board[x,y] = State.Alive;
                }
            }
        }

        public State GetStateAt(int x, int y)
        {
            return _board[x, y];
        }

        public void DrawBoard()
        {
            for (int y = 0; y < _board.GetLength(1); y++)
            {
                for (int x = 0; x < _board.GetLength(0); x++)
                {
                    Console.Write(GetCharacterRepresentation(_board[x, y]));
                }
                Console.Write("\n");
            }
        }

        private char GetCharacterRepresentation(State state)
        {
            switch(state)
            {
                case State.Dead:
                    return ' ';
                case State.Alive:
                    return '#';
                default:
                    return ' ';
            }
        }

        private int Neighbours(int x, int y)
        {
            // quit if given positioning is bad
            if ((x < 0 && x >= _board.GetLength(1) ||
                 y < 0 && y >= _board.GetLength(0)))
            {
                return -1;
            }

            var neighbours = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    // Temporary values to test against to see if they are legit
                    var dx = x + i;
                    var dy = y + j;

                    // Check bounds
                    if (dx >= 0 && dx < _board.GetLength(0) &&
                        dy >= 0 && dy < _board.GetLength(1))
                    {
                        // Checks all neighbours without checking itself
                        if (dx != x || dy != y)
                        {
                            // Add up if cell is alive
                            if (_board[dx, dy] > 0)
                                neighbours++;
                        }
                    }
                }
            }

            return neighbours;
        }
    }
}
