using System.Collections;
using System;
using System.Drawing;

namespace AlgorithmVisualiser
{
    public class Sort : IDisplayAlgorithm
    {
        System.Windows.Forms.Timer Delay = new System.Windows.Forms.Timer();
        private bool sorted = false;
        private int[] arr;
        private Graphics visuals;
        private int arrSize;
        private int dNum = 20;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        public void InsertSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int key = array[j];
                int i = j - 1;
                //g.FillRectangle(blackBrush, i+1 * dNum, 0, dNum, maxVal);
                //g.FillRectangle(greenBrush, i+1 * dNum, maxVal - array[i+1], dNum, maxVal);
                while (i >= 0 && array[i] > key)
                {

                    visuals.FillRectangle(blackBrush, (i + 1) * dNum, 0, dNum, arrSize);
                    visuals.FillRectangle(greenBrush, (i + 1) * dNum, arrSize - key, dNum, arrSize);
                    System.Threading.Thread.Sleep(30);
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, arrSize);
                    visuals.FillRectangle(redBrush, i * dNum, arrSize - array[i], dNum, arrSize);

                    System.Threading.Thread.Sleep(100);
                    array[i + 1] = array[i];
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, arrSize);
                    visuals.FillRectangle(blackBrush, (i+1) * dNum, 0, dNum, arrSize);
                    visuals.FillRectangle(whiteBrush, (i + 1) * dNum, arrSize - array[i], dNum, arrSize);
                    visuals.FillRectangle(whiteBrush, i * dNum, arrSize - key, dNum, arrSize);
                    i -= 1;
                }
                //g.FillRectangle(blackBrush, i * dNum, 0, dNum, maxVal);
                //g.FillRectangle(whiteBrush, i * dNum, maxVal - key, dNum, maxVal);
                array[i + 1] = key;
            }
            for(int k = 0; k < arr.Length; k++)
            {
                if(k== arr.Length-1 && arr[k-1]<=arr[k] || arr[k]<= arr[k+1])
                {
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, arrSize);
                    visuals.FillRectangle(greenBrush, k * dNum, arrSize - arr[k], dNum, arrSize);
                    System.Threading.Thread.Sleep(50);
                }
            }
            //|| i == array.Length - 1 && array[i - 1] <= array[i]
        }

        private void InsSwap(int i, int v)
        {
            arr[v] = arr[i];
        }

        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int ArrSize, string type)
        {
            arr = Arr;
            visuals = Visuals;
            arrSize = ArrSize;
            if (type == "InsertionSort")
            {
                InsertSort(Arr);
            }
        }

        private void Swap(int j, int p)
        {
            var temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;

            visuals.FillRectangle(blackBrush, j, 0, 1, arrSize);
            visuals.FillRectangle(blackBrush, p, 0, 1, arrSize);

            visuals.FillRectangle(whiteBrush, j, arrSize - arr[j], 1, arrSize);
            visuals.FillRectangle(whiteBrush, p, arrSize - arr[p], 1, arrSize);
        }
    }
}