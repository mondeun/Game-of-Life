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

        private State[,] _cell;
        private State[,] _lastCellFrame;
        private readonly Random _rand;

        /// <summary>
        /// Get board width
        /// </summary>
        public int Width => 45;

        /// <summary>
        /// Get board height
        /// </summary>
        public int Height => 22;

        public Board()
        {
            _cell = new State[Width, Height];
            _lastCellFrame = new State[Width, Height];
            _rand = new Random();
            Shuffle();
        }

        /// <summary>
        /// Shuffle around the cells
        /// </summary>
        public void Shuffle()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    int tmp = _rand.Next(0, 2);
                    if(tmp == 0)
                        _cell[x, y] = State.Dead;
                    else
                        _cell[x,y] = State.Alive;
                }
            }
        }

        /// <summary>
        /// Update the board and apply rules to the cells
        /// </summary>
        public void Update()
        {
            // TODO Add handling of deceased and born cells
            var tmpCells = (State[,])_cell.Clone();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var neighbours = CountNeighbours(x, y);

                    if (tmpCells[x, y] == State.Alive)
                    {
                        if (neighbours < 2 || neighbours > 3)
                            tmpCells[x, y] = State.Dead;
                        if (neighbours == 2 || neighbours == 3)
                            tmpCells[x, y] = State.Alive;
                    }
                    else
                    {
                        if (neighbours == 3)
                            tmpCells[x, y] = State.Alive;
                    }
                }
            }
            _cell = tmpCells;
        }

        /// <summary>
        /// Draw the board the console
        /// </summary>
        public void Draw()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    var piece = GetCharacterRepresentation(_cell[x, y]);
                    if(piece == '#')
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(piece);
                }
                Console.Write("\n");
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Translate a state to a character
        /// </summary>
        /// <param name="state">State to translate</param>
        /// <returns>Character representation of state</returns>
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

        /// <summary>
        /// Get the number of bordering neighbours that are in an alive state
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y Position</param>
        /// <returns>Number of alive neighbours</returns>
        private int CountNeighbours(int x, int y)
        {
            // quit if given positioning is bad
            if (x < 0 && x >= Width ||
                y < 0 && y >= Height)
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
                    if (dx < 0 || dx >= Width || dy < 0 || dy >= Height)
                        continue;

                    // Checks all neighbours without checking itself
                    if (dx != x || dy != y)
                    {
                        // Add up if cell is alive
                        if (_cell[dx, dy] > 0)
                            neighbours++;
                    }
                }
            }

            return neighbours;
        }
    }
}
