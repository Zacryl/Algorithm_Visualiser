using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace AlgorithmVisualiser
{
    public partial class Form1 : Form
    {
        int[] Arr;
        Graphics visuals;
        Thread algorithmThread;
        delegate string GetText();
        public Form1()
        {
            InitializeComponent();
            SelectedAlgorithm.Text = "Select Algorithm";
        }
        private void initialiseNewArray()
        {
            visuals = VisualPanel.CreateGraphics();
            int panelSize = VisualPanel.Width;
            int panelHeight = VisualPanel.Height;
            int arrSize = 40;
            int dNum = panelSize / arrSize;
            Arr = new int[arrSize];
            visuals.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Black), 0, 0, panelSize, panelHeight);
            Random rand = new Random();
            for(int i = 0; i<arrSize; i++){
                Arr[i] = rand.Next(0, panelHeight);
            }
            for(int i=0; i<arrSize; i++)
            {
                visuals.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), i* dNum, panelHeight - Arr[i], dNum, panelHeight);
            }
        }
        private string SelectedAlgorithmText()
        {
            return SelectedAlgorithm.Text;
        }
        private void chosenAlgorithm()
        {
            switch (SelectedAlgorithm.Invoke(new GetText(SelectedAlgorithmText)))
            {
                case "Insertion Sort":
                    IDisplayAlgorithm iSA = new InsertSort();
                    iSA.SortArray(Arr, visuals, VisualPanel.Width, VisualPanel.Height);
                    break;
                case "Bubble Sort":
                    IDisplayAlgorithm bSA = new BubbleSortDisplay();
                    bSA.SortArray(Arr, visuals, VisualPanel.Width, VisualPanel.Height);
                    break;
                case "Heap Sort":
                    IDisplayAlgorithm hSA = new HeapSortDisplay();
                    hSA.SortArray(Arr, visuals, VisualPanel.Width, VisualPanel.Height);
                    break;
                case "Find Max":
                    IDisplayAlgorithm fMA = new FindMaxDisplay();
                    fMA.SortArray(Arr, visuals, VisualPanel.Width, VisualPanel.Height);
                    break;
                case "Toppunkt1":
                    IDisplayAlgorithm tPA = new Toppunkt();
                    tPA.SortArray(Arr, visuals, VisualPanel.Width, VisualPanel.Height);
                    break;
                case "Merge Sort":
                    IDisplayAlgorithm mS = new MergeSort();
                    mS.SortArray(Arr, visuals, VisualPanel.Width, VisualPanel.Height);
                    break;
                default:
                    break;
            }
        }
        private void Reset_Click(object sender, EventArgs e)
        {
            initialiseNewArray();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (Arr != null)
            {
                chosenAlgorithm();
                //algorithmThread = new Thread(chosenAlgorithm);
                //algorithmThread.Start();
            }
            else
            {
                initialiseNewArray();
            }
        }

        private void SelectedAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
