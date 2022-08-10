﻿/* This color palette was sourced from the examples provided in:
 * Wong 2011, https://www.nature.com/articles/nmeth.1618.pdf
 * This 8-color palette has good overall variability and can be 
 * differentiated by individuals with red-green color blindness.
 */

namespace ScottPlot.Palettes;

public class ColorblindFriendly : HexPaletteBase, IPalette
{
    public override string Name => GetType().Name;

    public override string Description => string.Empty;

    internal override string[] HexColors => new string[]
    {
        "#000000", "#E69F00", "#56B4E9", "#009E73", "#F0E442",
        "#0072B2", "#D55E00", "#CC79A7",
    };
}
