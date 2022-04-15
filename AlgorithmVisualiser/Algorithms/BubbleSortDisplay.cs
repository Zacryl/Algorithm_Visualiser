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
       
        ///<param name="array">  
        ///Takes a type int[] array.
        /// </param>
        ///<summary> 
        /// Bubblesort Algorithm
        ///</summary>
        private void BubbleSort(int[] array)
        {
            while (!sorted)
            {
                for (int i = 1; i < array.Length; i++)
                {
                    ColorRed(i);
                    
                    if (arr[i] < arr[i - 1])
                    {
                        var temp = arr[i];
                        arr[i] = arr[i - 1];
                        arr[i - 1] = temp;
                    }

                    ColorRed(i);
                    ColorWhite(i);
                }
                sorted = isSorted();
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
        /// One time setup of the interface that starts the Bubblesort.
        ///</summary>
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

        ///<summary> 
        /// Checks if the it sorted and returns the result.
        ///</summary>
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
        ///<summary> 
        /// CheckArray is a visual/Debug tool that goes through the array and if the sort
        /// is done right it will color that visual bar green.
        ///</summary>
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
        public void ReDraw()
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
        }
        ///<param name="i">
        ///Takes int i which is the position and index of the array
        ///</param>
        ///<summary> 
        /// Colors the two parts about to be swapped red before it happens.
        ///</summary>
        private void ColorRed(int i)
        {
            visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, (i - 1) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, (i - 1) * dNum, panelHeight - arr[i - 1], dNum, panelHeight);
            System.Threading.Thread.Sleep(sleepTimer);
        }
        ///<param name="i">
        ///Takes int i which is the position and index of the array
        ///</param>
        ///<summary> 
        /// Colors everything not focused white.
        ///</summary>
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
            System.Threading.Thread.Sleep(sleepTimer);
        }
    }
}