using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmVisualiser
{
    public partial class Form1 : Form
    {
        int[] Arr;
        Graphics visuals;
        public Form1()
        {
            InitializeComponent();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            visuals = VisualPanel.CreateGraphics();
            int arrSize = VisualPanel.Width;
            int arrHeight = VisualPanel.Height;
            int dNum = 20;
            Arr = new int[arrSize/dNum];
            visuals.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, arrSize, arrHeight);
            Random rand = new Random();
            for(int i = 0; i<arrSize/dNum; i++){
                Arr[i] = rand.Next(0, arrHeight);
            }
            for(int i=0; i<arrSize/dNum; i++)
            {
                visuals.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i*dNum, arrHeight - Arr[i], dNum, arrHeight);
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            IDisplayAlgorithm dA = new Sort();
            dA.SortArray(Arr, visuals, VisualPanel.Height,"InsertionSort");
        }
    }
}
