﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmVisualiser
{
    interface IDisplayAlgorithm
    {
        void SortArray(int[] Arr, Graphics Visuals, int ArrSize, string type);
    }
}
