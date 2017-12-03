namespace sudokuFucker
{
    public class Sudoku
    {
        private int[] _matrix;


        public int[] Matrix
        {
            get => _matrix;
            set
            {
                if (value.Length == 81)
                {
                    _matrix = value;
                }
            }
        }

        public Sudoku()
        {
            Matrix = new[]{
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