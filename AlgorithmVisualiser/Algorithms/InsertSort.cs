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
        private int sleepTimer;
        Brush whiteBrush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
        Brush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        Brush redBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
        Brush greenBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Green);
        ///<param name="array">
        ///Takes a type int[] array.
        /// </param>
        /// </param>
        /// </param>
        /// </param>
        ///<summary> 
        /// InsertionSort Algorithm & Visualiser.
        ///</summary>
        private void InsertionSort(int[] array)
        {
            for (int j = 1; j < array.Length; j++)
            {
                int key = array[j];
                int i = j - 1;;
                visuals.FillRectangle(greenBrush, j * dNum, panelHeight - key, dNum, panelHeight);
                System.Threading.Thread.Sleep(sleepTimer);
                while (i >= 0 && array[i] > key)
                {
                    Color(i,key);
                    array[i + 1] = array[i];
                    i -= 1;
                }
                array[i + 1] = key;
                ColorWhite();
                ReDraw();
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
        /// One time setup of the interface that starts the InsertSort.
        ///</summary>
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            sleepTimer = Convert.ToInt32(dNum) * 3;
            InsertionSort(Arr);
            CheckArray();
        }

        ///<param name="i">
        ///<param name="key">
        ///Takes int i nad int key.
        ///</param>
        ///</param>
        ///<summary> 
        /// Colors the index i and the key red and white for swapping.
        ///</summary>
        private void Color(int i, int key)
        {
            visuals.FillRectangle(blackBrush, (i + 1) * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, (i + 1) * dNum, panelHeight - key, dNum, panelHeight);
            visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            System.Threading.Thread.Sleep(sleepTimer);
            visuals.FillRectangle(redBrush, (i + 1) * dNum, panelHeight - arr[i], dNum, panelHeight);
            visuals.FillRectangle(whiteBrush, (i + 1) * dNum, panelHeight - arr[i], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, i * dNum, panelHeight - key, dNum, panelHeight);
            System.Threading.Thread.Sleep(sleepTimer);
        }

        ///<summary> 
        /// Colors everything white
        ///</summary>
        private void ColorWhite()
        {
            for (int k = 0; k < arr.Length; k++)
            {
                {
                    visuals.FillRectangle(blackBrush, k * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, k * dNum, panelHeight - arr[k], dNum, panelHeight);
                }
            }
        }
        ///<summary> 
        /// CheckArray is a visual/Debug tool that goes through the array and if the sort
        /// is done right it will color that visual bar green.
        ///</summary>
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
        ///<summary> 
        /// Redraws the entire array in case it should dissapear.
        ///</summary>
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