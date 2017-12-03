using System;

namespace sudokuFucker
{
    public class Generate
    {
        private int len = 9;
        private Random rnd = new Random();
        public Sudoku _basic = new Sudoku(new[]
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

        private void Transposing()
        {
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    var ij = i * len + j;
                    var ji = j * len + i;
                    _basic.Matrix[ij] ^= _basic.Matrix[ji];
                    _basic.Matrix[ji] ^= _basic.Matrix[ij];
                    _basic.Matrix[ij] ^= _basic.Matrix[ji];
                }
            }
        }

        private void SwapRowsSmall()
        {
            var sector = rnd.Next(0, 3);
            var toswap1 = rnd.Next(0, 3);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, 3);
            }
            for (var i = 0; i < len; i++)
            {
                var temp = _basic.Matrix[9 * toswap1 + i + sector * 9 * 3];
                _basic.Matrix[9 * toswap1 + i + sector * 9 * 3] = _basic.Matrix[9 * toswap2 + i + sector * 9 * 3];
                _basic.Matrix[9 * toswap2 + i + sector * 9 * 3] = temp;
            }
        }

        private void SwapColumnsSmall()
        {
            var sector = rnd.Next(0, 3);
            var toswap1 = rnd.Next(0, 3);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, 3);
            }
            for (var i = 0; i < 81; i += 9)
            {
                var temp = _basic.Matrix[3 * sector + toswap1 + i];
                _basic.Matrix[3 * sector + toswap1 + i] = _basic.Matrix[3 * sector + toswap2 + i];
                _basic.Matrix[3 * sector + toswap2 + i] = temp;
            }
        }

        private void SwapRowsArea()
        {
            var toswap1 = rnd.Next(0, 3);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, 3);
            }
            for (var i = 0; i < len; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var temp = _basic.Matrix[27 * toswap1 + i + 9 * j];
                    _basic.Matrix[27 * toswap1 + i + 9 * j] = _basic.Matrix[27 * toswap2 + i + 9 * j];
                    _basic.Matrix[27 * toswap2 + i + 9 * j] = temp;
                }
            }
        }

        private void SwapColumnsArea()
        {
            var toswap1 = rnd.Next(0, 3);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, 3);
            }
            for (var i = 0; i < 81; i += 9)
            {
                for (var j = 0; j < 3; j++)
                {
                    var temp = _basic.Matrix[3 * toswap1 + i + j];
                    _basic.Matrix[3 * toswap1 + i + j] = _basic.Matrix[3 * toswap2 + i + j];
                    _basic.Matrix[3 * toswap2 + i + j] = temp;
                }
            }
        }

        private delegate void ShuffleMachine();
        
        public void Shuffle(int shuffles = 150)
        {
            var turns = new ShuffleMachine[6]
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