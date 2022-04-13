using System.Collections;
using System;
using System.Drawing;

namespace AlgorithmVisualiser
{
    public class Toppunkt : IDisplayAlgorithm
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
        public int Toppunkt1(int[] array)
        {
            visuals.FillRectangle(blackBrush, 0 * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, 0 * dNum, panelHeight - array[0], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, 1 * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(redBrush, 1 * dNum, panelHeight - array[1], dNum, panelHeight);
            System.Threading.Thread.Sleep(100);
            if (array[0] >= array[1])
            {
                visuals.FillRectangle(blackBrush, 0 * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(greenBrush, 0 * dNum, panelHeight - array[0], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, 1 * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, 1 * dNum, panelHeight - array[1], dNum, panelHeight);
                return 0;
            }
            visuals.FillRectangle(blackBrush, 0 * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(whiteBrush, 0 * dNum, panelHeight - array[0], dNum, panelHeight);
            visuals.FillRectangle(blackBrush, 1 * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(whiteBrush, 1 * dNum, panelHeight - array[1], dNum, panelHeight);
            System.Threading.Thread.Sleep(100);
            for (int i = 1; i <= array.Length - 2; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, (i-1) * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, (i - 1) * dNum, panelHeight - array[i - 1], dNum, panelHeight);
                System.Threading.Thread.Sleep(100);
                if (array[i - 1] <= array[i] && array[i] >= array[i + 1])
                {
                    visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(greenBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                    visuals.FillRectangle(blackBrush, (i-1) * dNum, 0, dNum, panelHeight);
                    visuals.FillRectangle(whiteBrush, (i-1) * dNum, panelHeight - array[i-1], dNum, panelHeight);
                    return i;
                }
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, i * dNum, panelHeight - array[i], dNum, panelHeight);
                visuals.FillRectangle(blackBrush, (i - 1) * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(redBrush, (i - 1) * dNum, panelHeight - array[i - 1], dNum, panelHeight);
                System.Threading.Thread.Sleep(100);
            }
            visuals.FillRectangle(blackBrush, array.Length-1 * dNum, 0, dNum, panelHeight);
            visuals.FillRectangle(greenBrush, array.Length - 1 * dNum, panelHeight - array[array.Length - 1], dNum, panelHeight);
            return array.Length - 1;
        }
        void IDisplayAlgorithm.SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight)
        {
            arr = Arr;
            visuals = Visuals;
            panelHeight = PanelHeight;
            panelWidth = PanelWidth;
            dNum = panelWidth / arr.Length;
            for(int i = 0; i < arr.Length; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
            Toppunkt1(Arr);
        }
        public void ReDraw()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                visuals.FillRectangle(blackBrush, i * dNum, 0, dNum, panelHeight);
                visuals.FillRectangle(whiteBrush, i * dNum, panelHeight - arr[i], dNum, panelHeight);
            }
        }
    }
}