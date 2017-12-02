namespace sudokuFucker
{
    public class Gimmicks
    {
        public static void Append(ref int[] arr, int newItem)
        {
            var kek = new int[arr.Length + 1];
            for (var i = 0; i < arr.Length; i++)
            {
                kek[i] = arr[i];
            }
            kek[arr.Length] = newItem;
            arr = kek;
        }
    }
}