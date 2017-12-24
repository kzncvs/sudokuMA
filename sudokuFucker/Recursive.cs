using System.Collections.Generic;
using System.Linq;

namespace sudokuFucker
{
    public class Recursive
    {
        private static List<int> FindAll(int num, int size)
        {
            var last = 0;
            var finarr = new List<int>();
            for (var i = 0; i < size * size + 1; i++)
            {
                var now = size * size * i;
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
            while (minval > size * size - 1)
            {
                minval -= size * size;
            }
            for (var i = minval; i < minval + size * size * size * size - size * size + 1; i += size * size)
            {
                finarr.Add(i);
            }

            var start = num - ((num / (size * size)) % size) * size * size - (num % size);
            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    finarr.Add(start + j + i * size * size);
                }
            }
            finarr.Remove(num);
            

            return finarr.Distinct().ToList();
        }

        private static bool CanWePut(int index, int value, List<int> matrix, int size)
        {
            foreach (var i in FindAll(index, size))
            {
                if (matrix[i] == value)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool RecursiveCount(ref Sudoku puzzle, ref int solutionsCount, int size, int k = 0)
        {
            if (k == size * size * size * size)
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
                    return RecursiveCount(ref puzzle, ref solutionsCount, size, k + 1);
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
                        if (CanWePut(k, i, puzzle.Matrix, size))
                        {
                            puzzle.Matrix[k] = i;
                            if (RecursiveCount(ref puzzle, ref solutionsCount, size, k + 1))
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
            RecursiveCount(ref ss, ref co, ss.Size);
            return !(co > 1);
        }

        private static bool Solver(ref Sudoku puzzle, int size, int k = 0)
        {
            if (k == size * size * size * size)
            {
                return true;
            }
            else
            {
                if (puzzle.Matrix[k] != 0)
                {
                    return Solver(ref puzzle, size, k + 1);
                }
                else
                {
                    var i = 1;
                    while (true)
                    {
                        if (i > size * size)
                        {
                            puzzle.Matrix[k] = 0;
                            return false;
                        }
                        if (CanWePut(k, i, puzzle.Matrix, size))
                        {
                            puzzle.Matrix[k] = i;
                            if (Solver(ref puzzle, size, k + 1))
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
            Solver(ref tmp, tmp.Size);
            return tmp;
        }
    }
}