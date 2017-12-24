using System;

namespace sudokuFucker
{
    public class Generate
    {
        private readonly int Size;
        private readonly int Diff;
        private readonly Random rnd = new Random();
        public Sudoku _basic;

        public Generate(int size, int diff = 0)
        {
            Size = size;
            if (Size == 3)
            {
                _basic = new Sudoku(new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9,
                    4, 5, 6, 7, 8, 9, 1, 2, 3,
                    7, 8, 9, 1, 2, 3, 4, 5, 6,

                    2, 3, 4, 5, 6, 7, 8, 9, 1,
                    5, 6, 7, 8, 9, 1, 2, 3, 4,
                    8, 9, 1, 2, 3, 4, 5, 6, 7,

                    3, 4, 5, 6, 7, 8, 9, 1, 2,
                    6, 7, 8, 9, 1, 2, 3, 4, 5,
                    9, 1, 2, 3, 4, 5, 6, 7, 8
                });
            }
            else if (Size == 2)
            {
                _basic = new Sudoku(new[]
                {
                    1, 2, 3, 4,
                    3, 4, 1, 2,
                    2, 1, 4, 3,
                    4, 3, 2, 1
                });
            }
            else if (Size == 4)
            {
                _basic = new Sudoku(new[]
                {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16,
                    5, 6, 7, 8, 1, 2, 3, 4, 13, 14, 15, 16, 9, 10, 11, 12,
                    9, 10, 11, 12, 13, 14, 15, 16, 1, 2, 3, 4, 5, 6, 7, 8,
                    13, 14, 15, 16, 9, 10, 11, 12, 5, 6, 7, 8, 1, 2, 3, 4,
                    2, 1, 4, 3, 6, 5, 8, 7, 10, 9, 12, 11, 14, 13, 16, 15,
                    6, 5, 8, 7, 2, 1, 4, 3, 14, 13, 16, 15, 10, 9, 12, 11,
                    10, 9, 12, 11, 14, 13, 16, 15, 2, 1, 4, 3, 6, 5, 8, 7,
                    14, 13, 16, 15, 10, 9, 12, 11, 6, 5, 8, 7, 2, 1, 4, 3,
                    3, 4, 1, 2, 7, 8, 5, 6, 11, 12, 9, 10, 15, 16, 13, 14,
                    7, 8, 5, 6, 3, 4, 1, 2, 15, 16, 13, 14, 11, 12, 9, 10,
                    11, 12, 9, 10, 15, 16, 13, 14, 3, 4, 1, 2, 7, 8, 5, 6,
                    15, 16, 13, 14, 11, 12, 9, 10, 7, 8, 5, 6, 3, 4, 1, 2,
                    4, 3, 2, 1, 8, 7, 6, 5, 12, 11, 10, 9, 16, 15, 14, 13,
                    8, 7, 6, 5, 4, 3, 2, 1, 16, 15, 14, 13, 12, 11, 10, 9,
                    12, 11, 10, 9, 16, 15, 14, 13, 4, 3, 2, 1, 8, 7, 6, 5,
                    16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1,
                });
            }
        }

        private void Transposing()
        {
            for (var i = 0; i < Size * Size; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    var ij = i * Size * Size + j;
                    var ji = j * Size * Size + i;
                    _basic.Matrix[ij] ^= _basic.Matrix[ji];
                    _basic.Matrix[ji] ^= _basic.Matrix[ij];
                    _basic.Matrix[ij] ^= _basic.Matrix[ji];
                }
            }
        }

        private void SwapRowsSmall()
        {
            var sector = rnd.Next(0, Size);
            var toswap1 = rnd.Next(0, Size);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, Size);
            }
            for (var i = 0; i < Size * Size; i++)
            {
                var temp = _basic.Matrix[Size * Size * toswap1 + i + sector * Size * Size * Size];
                _basic.Matrix[Size * Size * toswap1 + i + sector * Size * Size * Size] =
                    _basic.Matrix[Size * Size * toswap2 + i + sector * Size * Size * Size];
                _basic.Matrix[Size * Size * toswap2 + i + sector * Size * Size * Size] = temp;
            }
        }

        private void SwapColumnsSmall()
        {
            var sector = rnd.Next(0, Size);
            var toswap1 = rnd.Next(0, Size);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, Size);
            }
            for (var i = 0; i < Size * Size * Size * Size; i += Size * Size)
            {
                var temp = _basic.Matrix[Size * sector + toswap1 + i];
                _basic.Matrix[Size * sector + toswap1 + i] = _basic.Matrix[Size * sector + toswap2 + i];
                _basic.Matrix[Size * sector + toswap2 + i] = temp;
            }
        }

        private void SwapRowsArea()
        {
            var toswap1 = rnd.Next(0, Size);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, Size);
            }
            for (var i = 0; i < Size * Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    var temp = _basic.Matrix[Size * Size * Size * toswap1 + i + Size * Size * j];
                    _basic.Matrix[Size * Size * Size * toswap1 + i + Size * Size * j] =
                        _basic.Matrix[Size * Size * Size * toswap2 + i + Size * Size * j];
                    _basic.Matrix[Size * Size * Size * toswap2 + i + Size * Size * j] = temp;
                }
            }
        }

        private void SwapColumnsArea()
        {
            var toswap1 = rnd.Next(0, Size);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, Size);
            }
            for (var i = 0; i < Size * Size * Size * Size; i += Size * Size)
            {
                for (var j = 0; j < Size; j++)
                {
                    var temp = _basic.Matrix[Size * toswap1 + i + j];
                    _basic.Matrix[Size * toswap1 + i + j] = _basic.Matrix[Size * toswap2 + i + j];
                    _basic.Matrix[Size * toswap2 + i + j] = temp;
                }
            }
        }

        private delegate void ShuffleMachine();

        public void Shuffle(int shuffles = 150)
        {
            var turns = new ShuffleMachine[]
            {
                Transposing, SwapColumnsArea, SwapRowsArea, SwapColumnsArea, SwapRowsSmall, SwapColumnsSmall
            };
            for (var i = 0; i < shuffles; i++)
            {
                var kek = rnd.Next(0, 6);
                turns[kek]();
            }
        }
        
        
    }
}