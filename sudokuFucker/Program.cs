using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sudokuFucker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            
            var kek3 = new Sudoku(new[]
            {
                4, 0, 3, 0, 0, 2, 0, 0, 0,
                5, 0, 0, 0, 6, 0, 1, 2, 0,
                9, 0, 0, 0, 0, 0, 0, 0, 4,
                
                0, 0, 8, 0, 7, 0, 0, 0, 0,
                0, 0, 0, 2, 0, 3, 0, 0, 8,
                0, 3, 6, 0, 0, 0, 7, 0, 0,
                
                0, 7, 0, 9, 2, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 5, 0, 9, 6,
                0, 0, 0, 8, 0, 4, 5, 0, 0
            });
            
            var kek2 = new Sudoku(new[]
            {
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0,
            });
            
            
            var check = Recursive.Solve(new Sudoku(kek2));
            Console.WriteLine(check.SudokuToString());
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString() + " ms");
            
/*            var keek = new Generate(3);
            keek.Shuffle();
            Console.WriteLine(keek._basic.SudokuToString());*/

        }
    }
}