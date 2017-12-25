using System.Collections.Generic;

namespace sudokuFucker
{
    public class GUI_adapter
    {
        public List<int> Generate(int size, int difficult)
        {
            return new Generate(size, difficult).Make().Matrix;
        }

        public List<int> Solve(List<int> input)
        {
            return Recursive.Solve(new Sudoku(input.ToArray())).Matrix;
        }
    }
}