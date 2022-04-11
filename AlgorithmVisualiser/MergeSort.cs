using System.Collections;
using System;
using System.Drawing;
using System.Threading;

namespace AlgorithmVisualiser
{
    public class MergeSort : IDisplayAlgorithm
    {
        System.Windows.Forms.Timer Delay = new System.Windows.Forms.Timer();
        private int[] arr;
        private Graphics visuals;
        private int panelWidth;
        private int panelHeight;
        private int dNum;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush blueBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        Brush orangeBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        int sleepTimer = 80;
        int sndSleepTimer = 0;
        public void Merge(int[] array, int p, int q, int r)
        {
            int i, j, k;
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];
            visuals.FillRectangle(blackBrush, r * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, r * dNum, panelHeight - array[r], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, p * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, p * dNum, panelHeight - array[p], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, q * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(blueBrush, q * dNum, panelHeight - array[q], dNum, panelHeight);
            for (i = 0; i < n1; i++)
            {
                L[i] = array[p + i];
                if (p + i != p && p + i != q)
                {
                    visuals.FillRectangle(blackBrush, (p + i) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, (p + i) * dNum, panelHeight - array[p + i], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, (q + i + 1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, (q + i + 1) * dNum, panelHeight - array[q + i + 1], dNum, panelHeight);
                    //visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    //visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    Thread.Sleep(sleepTimer);
                    visuals.FillRectangle(blackBrush, (p + i) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, (p + i) * dNum, panelHeight - array[p + i], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, (q + i + 1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, (q + i + 1) * dNum, panelHeight - array[q + i + 1], dNum, panelHeight);
                    //visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    //visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    Thread.Sleep(sndSleepTimer);
                }
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = array[q + j + 1];
                if (q + j + 1 != r)
                {
                    /*visuals.FillRectangle(blackBrush, (q + j + 1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, (q + j + 1) * dNum, panelHeight - array[q + j + 1], dNum, panelHeight);
                    //visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    //visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);

                    Thread.Sleep(sleepTimer);
                    visuals.FillRectangle(blackBrush, (q + j + 1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, (q + j + 1) * dNum, panelHeight - array[q + j + 1], dNum, panelHeight);
                    //visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    //visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    Thread.Sleep(sndSleepTimer);*/
                }
            }
            i = 0;
            j = 0;
            k = p;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {

                    array[k] = L[i++];
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                    Thread.Sleep(sleepTimer);
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                    Thread.Sleep(sndSleepTimer);
                }
                else
                {
                    array[k] = R[j++];
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(redBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                    Thread.Sleep(sleepTimer);
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                    Thread.Sleep(sndSleepTimer);
                }
                k++;
            }
            while (i < n1)
            {
                array[k] = L[i];
                visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                Thread.Sleep(sleepTimer);
                visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                Thread.Sleep(sndSleepTimer);
                i++;
                k++;
            }
            while (j < n2)
            {
                array[k] = R[j];
                visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                Thread.Sleep(sleepTimer);
                visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - array[k], dNum, panelHeight);
                Thread.Sleep(sndSleepTimer);
                k++;
                j++;
            }
        }
        public void Sort(int[] array, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                Sort(array, p, q);
                Sort(array, q + 1, r);
                Merge(array, p, q, r);
            }
        }
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            Sort(arr,0,arr.Length-1);
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
    }
}