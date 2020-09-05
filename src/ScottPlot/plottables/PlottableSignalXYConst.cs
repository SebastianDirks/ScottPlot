﻿using ScottPlot.MinMaxSearchStrategies;
using System;
using System.Drawing;

namespace ScottPlot
{
    public class PlottableSignalXYConst<TX, TY> : PlottableSignalXYGeneric<TX, TY> where TX : struct, IComparable where TY : struct, IComparable
    {
        public PlottableSignalXYConst(TX[] xs, TY[] ys, Color color, double lineWidth, double markerSize, string label, int minRenderIndex, int maxRenderIndex, LineStyle lineStyle, bool useParallel, IMinMaxSearchStrategy<TY> minMaxSearchStrategy = null, bool fill = false, Color? fillColor1 = null, Color? fillColor2 = null)
            : base(xs, ys, color, lineWidth, markerSize, label, minRenderIndex, maxRenderIndex, lineStyle, useParallel, new SegmentedTreeMinMaxSearchStrategy<TY>(), fill, fillColor1, fillColor2)
        {

        }

        public override string ToString()
        {
            string label = string.IsNullOrWhiteSpace(this.label) ? "" : $" ({this.label})";
            return $"PlottableSignalXYConst{label} with {GetPointCount()} points ({typeof(TX).Name}, {typeof(TY).Name})";
        }
    }
}
