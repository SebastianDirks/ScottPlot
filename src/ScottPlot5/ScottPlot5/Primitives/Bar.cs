﻿namespace ScottPlot;

/// <summary>
/// Represents a single bar in a bar chart
/// </summary>
public class Bar
{
    public double Position;
    public double Value;
    public double ValueBase = 0;
    public double Error = 0;

    public Color FillColor = Colors.Gray;
    public Color BorderColor = Colors.Black;
    public Color ErrorColor = Colors.Black;

    public double Size = 0.8; // coordinate units
    public double ErrorSize = 0.2; // coordinate units
    public float BorderLineWidth = 1;
    public float ErrorLineWidth = 0;

    // TODO: something like ErrorInDirectionOfValue?
    // Maybe ErrorPosition should be an enum containing: None, Upward, Downward, Both, or Extend
    public bool ErrorPositive = true;
    public bool ErrorNegative = true;

    public readonly Orientation Orientation = Orientation.Vertical; //TODO: support horizontal bar charts

    internal CoordinateRect Rect
    {
        get
        {
            return new CoordinateRect(
                left: Position - Size / 2,
                right: Position + Size / 2,
                bottom: ValueBase,
                top: Value);
        }
    }

    internal IEnumerable<CoordinateLine> ErrorLines
    {
        get
        {
            CoordinateLine center = new(Position, Value - Error, Position, Value + Error);
            CoordinateLine top = new(Position - ErrorSize / 2, Value + Error, Position + ErrorSize / 2, Value + Error);
            CoordinateLine bottom = new(Position - ErrorSize / 2, Value - Error, Position + ErrorSize / 2, Value - Error);
            return new List<CoordinateLine>() { center, top, bottom };
        }
    }

    internal AxisLimits AxisLimits
    {
        get
        {
            return new AxisLimits(
                left: Position - Size / 2,
                right: Position + Size / 2,
                bottom: ValueBase - Error,
                top: Value + Error);
        }
    }

    public void Render(RenderPack rp, IAxes axes, SKPaint paint)
    {
        PixelRect rect = axes.GetPixelRect(Rect);
        Drawing.Fillectangle(rp.Canvas, rect, FillColor);
        Drawing.DrawRectangle(rp.Canvas, rect, BorderColor, BorderLineWidth);

        if (Error == 0)
            return;

        foreach (CoordinateLine line in ErrorLines)
        {
            Pixel pt1 = axes.GetPixel(line.Start);
            Pixel pt2 = axes.GetPixel(line.End);
            Drawing.DrawLine(rp.Canvas, paint, pt1, pt2, BorderColor, BorderLineWidth);
        }
    }
}