using System.Collections;
using System;
namespace AlgorithmVisualiser
{
    public class InsertionSort : ISortAlgor
    {
        ///<param name="array">
        ///Takes a type int[] array and int x
        ///</param>
        ///</param>
        ///<summary> 
        ///An Algorithm that in Θ(n^2) time
        ///</summary>
        public void InsertSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int key = array[j];
                int i = j - 1;
                while (i >= 0 && array[i] > key)
                {
                    array[i + 1] = array[i];
                    i -= 1;
                }
                array[i + 1] = key;
            }
        }
    }
}