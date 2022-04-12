using System.Collections;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlgorithmVisualiser
{
    public class HeapSortDisplay : IDisplayAlgorithm
    {
        System.Windows.Forms.Timer Delay = new System.Windows.Forms.Timer();
        private int[] arr;
        private Graphics visuals;
        private float panelWidth;
        private float panelHeight;
        private float dNum;
        private int SleepTimer = 20;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush blueBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        Brush orangeBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        Brush pinkBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Pink);
        public void MaxHeapify(int[] A, int n, int i)
        {
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int largest = i;
            if (l < n && A[l] > A[largest])
            {
                largest = l;
            }
            if (r < n && A[r] > A[largest])
            {
                largest = r;
            }
            if (largest != i)
            {
                var temp = A[i];
                A[i] = A[largest];
                A[largest] = temp;
                MaxHeapify(A, n, largest);
            }
        }
        public void BuildMaxHeap(int[] A, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(A, n, i);
            }
        }
        public void HeapSort(int[] A, int n)
        {
            BuildMaxHeap(A, n);
            for (int i = n - 1; i > 0; i--)
            {
                var temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                MaxHeapify(A, i, 0);
            }
        }
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            }
            HeapSort(arr,arr.Length);
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