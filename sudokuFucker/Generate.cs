using System;

namespace sudokuFucker
{
    public class Generate
    {
        private readonly int Size;
        private readonly Random rnd = new Random();
        public Sudoku _basic;

        public Generate(int size)
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