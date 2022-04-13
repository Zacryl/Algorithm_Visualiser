using System.Collections;
using System;
using System.Drawing;

namespace AlgorithmVisualiser
{
    public class InsertSort : IDisplayAlgorithm
    {
        System.Windows.Forms.Timer Delay = new System.Windows.Forms.Timer();
        private int[] arr;
        private Graphics visuals;
        private float panelWidth;
        private float panelHeight;
        private float dNum;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        public void InsertionSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int key = array[j];
                int i = j - 1;;
                visuals.FillRectangle(greenBrush, j * dNum, panelHeight - key, dNum, panelHeight);
                System.Threading.Thread.Sleep(50);
                while (i >= 0 && array[i] > key)
                {
                    
                    
                    visuals.FillRectangle(blackBrush, (i+1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, (i+1) * dNum, panelHeight - key, dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    System.Threading.Thread.Sleep(50);
                    visuals.FillRectangle(redBrush, (i + 1) * dNum, panelHeight - array[i], dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, (i + 1) * dNum, panelHeight - array[i], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, i * dNum, panelHeight - key, dNum, panelHeight);
                    System.Threading.Thread.Sleep(50);
                    array[i + 1] = array[i];
                    i -= 1;
                }
                array[i + 1] = key;
                for (int k = 0; k < arr.Length; k++)
                {
                    {
                        visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                        visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
                    }
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
            InsertionSort(Arr);
            for (int k = 0; k < arr.Length; k++)
            {
                if (k == arr.Length - 1 && arr[k - 1] <= arr[k] || arr[k] <= arr[k + 1])
                {
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
                    System.Threading.Thread.Sleep(50);
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(greenBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
                }
            }
        }
    }
}