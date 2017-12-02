﻿using System;
using System.Diagnostics;
using static sudokuFucker.Sudoku;
using static sudokuFucker.Recursive;

namespace sudokuFucker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //var stopWatch = new Stopwatch();
            //stopWatch.Start();
            var kek = new Sudoku(new int[81]
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
            var solved = Recursive.Solve(kek);
            //stopWatch.Stop();
            Console.WriteLine(solved.SudokuToString());
            //Console.WriteLine(stopWatch.ElapsedMilliseconds.ToString() + " ms");
        }
    }
}