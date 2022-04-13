using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    /// <summary> 
    /// Interface that is used as an event handler for sorting array.
    /// </summary>
    interface IDisplayAlgorithm
    {
        void SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight);
        void ReDraw();
    }
}
