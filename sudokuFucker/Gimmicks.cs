using System;

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

        public static void Clear(ref int[] arr)
        {
            var clear = new int[0];
            foreach (var i in arr)
            {
                if (Array.IndexOf(clear, i) == -1)
                {
                    Append(ref clear, i);
                }
            }
            arr = clear;
        }

        public void temp()
        {
            var arr = new int[81][];
            arr[0] = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
        }
    }
}