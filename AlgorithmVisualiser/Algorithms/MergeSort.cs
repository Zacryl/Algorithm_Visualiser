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
        private float panelWidth;
        private float panelHeight;
        private float dNum;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        Brush blueBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        Brush orangeBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Orange);
        int sleepTimer;
        int sndSleepTimer = 0;

        ///<param name="array">
        ///<param name="p">  
        ///<param name="q">
        ///<param name="r">  
        ///Takes a type int[] array an int p left border of the array, int r for right and q for 
        ///middle
        /// </param>
        /// </param>
        /// </param>
        /// </param>
        ///<summary> 
        ///For MergeSort use Sort method instead of this method. - Merge part of Merge Sort Algorithm.
        ///</summary>
        void Merge(int[] array, int p, int q, int r)
        {
            int i, j, k;
            int n1 = q - p + 1;
            int n2 = r - q;
            int[] L = new int[n1];
            int[] R = new int[n2];

            InitialColors(p, q, r);

            for (i = 0; i < n1; i++)
            {
                L[i] = array[p + i];
                if (p + i != p && p + i != q)
                {
                    CompareColors(i,q,p,r);
                }
            }
            for (j = 0; j < n2; j++)
            {
                R[j] = array[q + j + 1];
            }
            i = 0;
            j = 0;
            k = p;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {

                    array[k] = L[i++];
                    RedWhiteColor(k);
                }
                else
                {
                    array[k] = R[j++];
                    RedWhiteColor(k);

                }
                k++;
            }
            while (i < n1)
            {
                array[k] = L[i];
                RedWhiteColor(k);

                i++;
                k++;
            }
            while (j < n2)
            {
                array[k] = R[j];
                RedWhiteColor(k);
                k++;
                j++;
            }
        }

        ///<param name="array">
        ///<param name="p">  
        ///<param name="r"> 
        ///Takes a type int[] array an int p left border of the array, int r for right.
        ///middle
        /// </param>
        /// </param>
        /// </param>
        ///<summary> 
        ///MergeSort method. Algorithm runs O(nlog(n))
        ///</summary>
        private void Sort(int[] array, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                Sort(array, p, q);
                Sort(array, q + 1, r);
                Merge(array, p, q, r);
            }
        }

        ///<param name="Arr">
        ///<param name="Visuals">  
        ///<param name="PanelWidth">
        ///<param name="PanelHeight">  
        ///Takes a type int[] Arr, Graphics Visuals, int PanelWidth for the height of the panel, 
        ///int PanelHeight for the height of the panel
        ///middle
        /// </param>
        /// </param>
        /// </param>
        /// </param>
        ///<summary> 
        /// One time setup of the interface that starts the MergeSort.
        ///</summary>
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            sleepTimer = Convert.ToInt32(dNum*2.5f);
            Sort(arr,0,arr.Length-1);
            CheckArray();
        }
        void CheckArray()
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
        void InitialColors(int p, int q ,int r)
        {
            visuals.FillRectangle(blackBrush, r * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, r * dNum, panelHeight - arr[r], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, p * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, p * dNum, panelHeight - arr[p], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, q * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(blueBrush, q * dNum, panelHeight - arr[q], dNum, panelHeight);
        }
        void RedWhiteColor(int k)
        {
            visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
            Thread.Sleep(sleepTimer);
            visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
            Thread.Sleep(sndSleepTimer);
        }
        private void CompareColors(int i, int p, int q, int r)
        {
            visuals.FillRectangle(blackBrush, (p + i) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, (p + i) * dNum, panelHeight - arr[p + i], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, (q + i + 1) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, (q + i + 1) * dNum, panelHeight - arr[q + i + 1], dNum, panelHeight);
            Thread.Sleep(sleepTimer);
            visuals.FillRectangle(blackBrush, (p + i) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(whiteBrush, (p + i) * dNum, panelHeight - arr[p + i], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, (q + i + 1) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(whiteBrush, (q + i + 1) * dNum, panelHeight - arr[q + i + 1], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, q * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(blueBrush, q * dNum, panelHeight - arr[q], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, r * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, r * dNum, panelHeight - arr[r], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, p * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, p * dNum, panelHeight - arr[p], dNum, panelHeight);
            Thread.Sleep(sndSleepTimer);
        }
        public void ReDraw()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
        }
    }
}