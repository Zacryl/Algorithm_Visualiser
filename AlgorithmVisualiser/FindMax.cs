using System.Collections;
using System;
using System.Drawing;

namespace AlgorithmVisualiser
{
    public class FindMaxDisplay : IDisplayAlgorithm
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
        public int FindMax(int[] array)
        {
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                visuals.FillRectangle(blackBrush, max * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, max * dNum, panelHeight - array[max], dNum, panelHeight);
                System.Threading.Thread.Sleep(100);
                if (array[i] >= array[max])
                {
                    visuals.FillRectangle(blackBrush, max * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, max * dNum, panelHeight - array[max], dNum, panelHeight);
                    max = i;
                }
            }
            visuals.FillRectangle(blackBrush, max * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, max * dNum, panelHeight - array[max], dNum, panelHeight);
            return max;
        }
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            Array.Sort(arr);
            for(int i = 0; i < arr.Length; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
            FindMax(Arr);
        }
    }
}