using System.Collections;
using System;
using System.Drawing;

namespace AlgorithmVisualiser
{
    public class BubbleSortDisplay : IDisplayAlgorithm
    {
        System.Windows.Forms.Timer Delay = new System.Windows.Forms.Timer();
        private int[] arr;
        private Graphics visuals;
        private int panelWidth;
        private int panelHeight;
        private int dNum;
        private bool sorted = false;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        public void BubbleSort(int[] array)
        {
            while (!sorted)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, (i-1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, (i-1) * dNum, panelHeight - array[i-1], dNum, panelHeight);
                    System.Threading.Thread.Sleep(50);
                    if (arr[i] < arr[i - 1])
                    {
                        var temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }
                    System.Threading.Thread.Sleep(50);
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, (i - 1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, (i - 1) * dNum, panelHeight - array[i - 1], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                }
                sorted = isSorted();
            }
            for (int k = 0; k < arr.Length; k++)
            {
                if (k == arr.Length - 1 && arr[k - 1] <= arr[k] || arr[k] <= arr[k + 1])
                {
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(greenBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
                    System.Threading.Thread.Sleep(50);
                }
            }
        }

        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            BubbleSort(Arr);
        }

        private bool isSorted()
        {
            for(int j = 1; j<arr.Length; j++)
            {
                if (arr[j] < arr[j - 1])
                {
                    return false;
                }
            }
            return true;
        }
    }
}