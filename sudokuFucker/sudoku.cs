namespace sudokuFucker
{
    public class Sudoku
    {
        public int[] Matrix;

        public Sudoku()
        {
            Matrix = new int[81]
            {
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0
            };
        }

        public Sudoku(int[] input)
        {
            Matrix = input;
        }

        public string SudokuToString()
        {
            var fin = "";
            for (var i = 1; i < 82; i++)
            {
                fin += Matrix[i - 1];
                if (i % 9 == 0)
                {
                    fin += "\n";
                }
                else if (i % 3 == 0)
                {
                    fin += " ";
                }
                if (i % 27 == 0)
                {
                    fin += "\n";
                }
            }
            return fin;
        }
    }
}