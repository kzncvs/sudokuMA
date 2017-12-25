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
/*            
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
                       
            var check = Recursive.Solve(new Sudoku(kek3));
            Console.WriteLine(check.SudokuToString());*/

            var keek = new Generate(2, 0);
            var ll = keek.Make();
            Console.WriteLine(ll.SudokuToString());

            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString() + " ms");
        }
    }
}