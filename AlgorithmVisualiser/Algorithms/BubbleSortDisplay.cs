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
        private float panelWidth;
        private float panelHeight;
        private float dNum;
        private int sleepTimer;
        private bool sorted = false;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        private void BubbleSort(int[] array)
        {
            while (!sorted)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    ColorPre(i);
                    
                    if (arr[i] < arr[i - 1])
                    {
                        var temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }

                    ColorPost(i);
                }
                sorted = isSorted();
            }
        }

        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            sleepTimer = Convert.ToInt32(dNum) * 2;
            BubbleSort(Arr);
            CheckArray();
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
        private void CheckArray()
        {
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
        private void ColorPre(int i)
        {
            visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, (i - 1) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, (i - 1) * dNum, panelHeight - arr[i - 1], dNum, panelHeight);
            System.Threading.Thread.Sleep(sleepTimer);
        }
        private void ColorPost(int i)
        {
            visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, (i - 1) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, (i - 1) * dNum, panelHeight - arr[i - 1], dNum, panelHeight);
            System.Threading.Thread.Sleep(sleepTimer);
            ColorWhite(i);
            System.Threading.Thread.Sleep(sleepTimer);
        }
        private void ColorWhite(int i)
        {
            int k = i-1;
            if(i == arr.Length-1)
            {
                k = i;
            }
            for(int j = 0; j <= k; j++)
            {
                visuals.FillRectangle(blackBrush, j * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, j * dNum, panelHeight - arr[j], dNum, panelHeight);
            }
        }
    }
}