﻿using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;

namespace sudokuFucker
{
    public class Recursive
    {
        private static List<int> FindAll(int num)
        {
            var last = 0;
            var finarr = new List<int>();
            for (var i = 0; i < 10; i++)
            {
                var now = 9 * i;
                if (num < now && num >= last)
                {
                    for (var j = last; j < now; j++)
                    {
                        finarr.Add(j);
                    }
                    break;
                }
                else
                {
                    last = now;
                }
            }
            var minval = num;
            while (minval > 8)
            {
                minval -= 9;
            }
            for (var i = minval; i < minval + 73; i += 9)
            {
                finarr.Add(i);
            }
            var nines = new[,]
            {
                {0, 1, 2, 9, 10, 11, 18, 19, 20},
                {3, 4, 5, 12, 13, 14, 21, 22, 23},
                {6, 7, 8, 15, 16, 17, 24, 25, 26},
                {27, 28, 29, 36, 37, 38, 45, 46, 47},
                {30, 31, 32, 39, 40, 41, 48, 49, 50},
                {33, 34, 35, 42, 43, 44, 51, 52, 53},
                {54, 55, 56, 63, 64, 65, 72, 73, 74},
                {57, 58, 59, 66, 67, 68, 75, 76, 77},
                {60, 61, 62, 69, 70, 71, 78, 79, 80}
            };
          //NEED REFACTORING!!!
            for (var i = 0; i < 9; i++)
            {
                for (var j = 0; j < 9; j++)
                {
                    if (nines[i, j] == num)
                    {
                        for (var k = 0; k < 9; k++)
                        {
                            finarr.Add(nines[i, k]);
                        }
                        break;
                    }
                }
            }

            return finarr.Distinct().ToList();
        }

        private static bool CanWePut(int index, int value, List<int> matrix)
        {
            foreach (var i in FindAll(index))
            {
                if (matrix[i] == value)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool RecursiveCount(ref Sudoku puzzle, ref int solutionsCount, int k = 0)
        {
            if (k == 81)
            {
                solutionsCount++;
                if (solutionsCount > 1)
                {
                    return true;
                }
                return false;
            }
            else
            {
                if (puzzle.Matrix[k] != 0)
                {
                    return RecursiveCount(ref puzzle, ref solutionsCount, k + 1);
                }
                else
                {
                    var i = 1;
                    while (true)
                    {
                        if (i > 9)
                        {
                            puzzle.Matrix[k] = 0;
                            return false;
                        }
                        if (CanWePut(k, i, puzzle.Matrix))
                        {
                            puzzle.Matrix[k] = i;
                            if (RecursiveCount(ref puzzle, ref solutionsCount, k + 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            i += 1;
                        }
                    }
                }
            }
        }

        public static bool IsSolutionOlnyOne(Sudoku puzzle)
        {
            var ss = puzzle;
            var co = 0;
            RecursiveCount(ref ss, ref co);
            return !(co > 1);
        }
        
        private static bool Solver(ref Sudoku puzzle, int k = 0)
        {
            if (k == 81)
            {
                return true;
            }
            else
            {
                if (puzzle.Matrix[k] != 0)
                {
                    return Solver(ref puzzle,  k + 1);
                }
                else
                {
                    var i = 1;
                    while (true)
                    {
                        if (i > 9)
                        {
                            puzzle.Matrix[k] = 0;
                            return false;
                        }
                        if (CanWePut(k, i, puzzle.Matrix))
                        {
                            puzzle.Matrix[k] = i;
                            if (Solver(ref puzzle, k + 1))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            i += 1;
                        }
                    }
                }
            }
        }

        public static Sudoku Solve(Sudoku puzzle)
        {
            var tmp = puzzle;
            Solver(ref tmp);
            return tmp;
        }
    }
}