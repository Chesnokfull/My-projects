using System;

namespace ExtensionMethods
{
    public static class ArrayExtension
    {
        public static Array MySort(this int[] arr)
        {
            int temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
                    {
                        // меняем элементы местами
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
            return arr;
        }
    }
    class ExtensionMethods
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 3, 5, 7, 1, 3, 9, 3, 2, 11 };

            arr.MySort();
            for (int i = 0; i < arr.Length - 1; i++)
                Console.WriteLine(arr[i]);
        }
    }
}
