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
        private int SleepTimer;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush orangeBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        Brush purpleBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Purple);
        int ReDrawPurple;
        
        private void MaxHeapify(int[] A, int n, int i)
        {
            //Algorithm
            int l = 2 * i + 1;
            int r = 2 * i + 2;
            int largest = i;
            
            //Visuals
            InitialVisual(i, l, r, n);

            //Algorithm
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
                //Visuals
                SwapColor(i, largest);
                
                //Algorithm
                var temp = arr[i];
                arr[i] = arr[largest];
                arr[largest] = temp;


                //Visuals
                SwapColor(i, largest);
                ReColor(i, largest,"green");
                whiteRLI(l, n, r, i);

                //Algorithm
                MaxHeapify(A, n, largest);
            }
            //Visuals
            whiteRLI(l,n,r,i);
        }

        public void BuildMaxHeap(int[] A, int n)
        {
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(A, n, i);
            }
        }
        private void HeapSort(int[] A, int n)
        {
            BuildMaxHeap(A, n);
            for (int i = n - 1; i > 0; i--)
            {
                //Visuals
                SwapColor(i, 0);
                
                //Algorithm
                var temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                
                //Visuals
                SwapColor(i, 0);
                ReColor(i, 0,"sort");
                //FIX THIS (Only attempt at implement) (Dinner time)
                //ReDrawPurple = i;
                //ReDraw();
                //Algorithm
                MaxHeapify(A, i, 0);
            }
        }
        //1 time setup
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            SleepTimer = Convert.ToInt32(dNum * 2.5f);
            HeapSort(arr,arr.Length);
            CheckArray();

        }
        public void ReDraw()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i > ReDrawPurple)
                {
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(purpleBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
                }
                else
                {
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
                }

            }
        }

        //Color methods
        private void ReColor(int k, int v, string Type)
        {
            Brush Color1 = greenBrush;
            Brush Color2 = greenBrush;
            if (Type == "sort")
            {
                Color1 = purpleBrush;
                Color2 = whiteBrush;
            }
            visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(Color1, k * dNum, panelHeight - arr[k], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, v * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(Color2, v * dNum, panelHeight - arr[v], dNum, panelHeight);
            System.Threading.Thread.Sleep(SleepTimer);
        }
        private void SwapColor(int k, int v)
        {
            visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, v * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, v * dNum, panelHeight - arr[v], dNum, panelHeight);
            System.Threading.Thread.Sleep(SleepTimer);
        }
        private void whiteRLI(int l, int n, int r, int i)
        {
            if (l < n && r < n)
            {
                visuals.FillRectangle(blackBrush, l * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, l * dNum, panelHeight - arr[l], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, r * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, r * dNum, panelHeight - arr[r], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
            else if (r < n)
            {
                visuals.FillRectangle(blackBrush, r * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, r * dNum, panelHeight - arr[r], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
            else if (l < n)
            {
                visuals.FillRectangle(blackBrush, l * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, l * dNum, panelHeight - arr[l], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
            else
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
        }
        private void InitialVisual(int i, int l, int r, int n)
        {
            visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            if (l < n)
            {
                visuals.FillRectangle(blackBrush, l * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(greenBrush, l * dNum, panelHeight - arr[l], dNum, panelHeight);
            }
            if (r < n)
            {
                visuals.FillRectangle(blackBrush, r * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(greenBrush, r * dNum, panelHeight - arr[r], dNum, panelHeight);
            }
            System.Threading.Thread.Sleep(SleepTimer);
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
    }
}