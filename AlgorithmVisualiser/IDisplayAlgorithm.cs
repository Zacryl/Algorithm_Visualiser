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
        ///<summary> 
        /// CheckArray is a visual/Debug tool that goes through the array and if the sort
        /// is done right it will color that visual bar green.
        ///</summary>
        void SortArray(int[] Arr, Graphics Visuals, int PanelWidth, int PanelHeight);
        void ReDraw();
    }
}
