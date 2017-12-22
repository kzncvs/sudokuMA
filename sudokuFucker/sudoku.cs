using System;
using System.Collections.Generic;
using System.Linq;

namespace sudokuFucker
{
    public class Sudoku
    {
        public readonly List<int> Matrix;
        public readonly int Size;

        public Sudoku(int[] input)
        {
            Size = (int) Math.Sqrt(Math.Sqrt(input.Length));
            Matrix = input.ToList();
        }

        public Sudoku(Sudoku prev)
        {
            Size = prev.Size;
            Matrix = new List<int>(prev.Matrix);
        }

        public string SudokuToString()
        {
            var fin = "";
            for (var i = 1; i < Size * Size * Size * Size + 1; i++)
            {
                fin += Matrix[i - 1];
                if (i % (Size * Size) == 0)
                {
                    fin += "\n";
                }
                else if (i % Size == 0)
                {
                    fin += " ";
                }
                if (i % (Size * Size * Size) == 0)
                {
                    fin += "\n";
                }
            }
            return fin;
        }
    }
}