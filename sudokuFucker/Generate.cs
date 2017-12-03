using System;

namespace sudokuFucker
{
    public class Generate
    {
        private int len = 9;
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

        public void Transposing()
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

        public void SwapRowsSmall()
        {
            var rnd = new Random();
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

        public void SwapColumnsSmall()
        {
            var rnd = new Random();
            var sector = rnd.Next(0, 3);
            var toswap1 = rnd.Next(0, 3);
            var toswap2 = toswap1;
            while (toswap2 == toswap1)
            {
                toswap2 = rnd.Next(0, 3);
            }
            Console.WriteLine(sector + " " + toswap1 + " " + toswap2);
            for (var i = 0; i < 81; i+=9)
            {
                var temp = _basic.Matrix[3 * sector + toswap1 + i];
                _basic.Matrix[3 * sector + toswap1 + i] = _basic.Matrix[3 * sector + toswap2 + i];
                _basic.Matrix[3 * sector + toswap2 + i] = temp;
            }
        }
        
    }
}