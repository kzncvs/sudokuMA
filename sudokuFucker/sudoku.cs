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
            Matrix = input.ToList();
            Size = (int) Math.Sqrt(Math.Sqrt(Matrix.Count));
        }

        public Sudoku(Sudoku prev)
        {
            Matrix = new List<int>(prev.Matrix);
        }

        public string SudokuToString()
        {
            var fin = "";
            for (var i = 1; i < 82; i++)
            {
                fin += Matrix[i - 1];
                if (i % 9 == 0)
                {
                    fin += "\n";
                }
                else if (i % 3 == 0)
                {
                    fin += " ";
                }
                if (i % 27 == 0)
                {
                    fin += "\n";
                }
            }
            return fin;
        }
    }
}