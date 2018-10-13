//  Copyright (C) 2009-2016 Christopher Brochtrup
//
//  This file is part of subs2srs.
//
//  subs2srs is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  subs2srs is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with subs2srs.  If not, see <http://www.gnu.org/licenses/>.
//
//////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Drawing;

namespace subs2srs
{
    /// <summary>
    /// Represents a .ass subtitle style.
    /// </summary>
    public class InfoStyle
    {
        public Font Font { get; set; } = new Font(new FontFamily("Arial"), 20, FontStyle.Regular);

        public Color ColorPrimary { get; set; } = Color.White;

        public Color ColorSecondary { get; set; } = Color.Red;

        public Color ColorOutline { get; set; } = Color.Black;

        public Color ColorShadow { get; set; } = Color.Black;

        public int OpacityPrimary { get; set; } = 0;

        public int OpacitySecondary { get; set; } = 0;

        public int OpacityOutline { get; set; } = 0;

        public int OpacityShadow { get; set; } = 0;

        public int Outline { get; set; } = 2;

        public int Shadow { get; set; } = 2;

        public bool OpaqueBox { get; set; } = false;

        public int Alignment { get; set; } = 2;

        public int MarginLeft { get; set; } = 10;

        public int MarginRight { get; set; } = 10;

        public int MarginVertical { get; set; } = 10;

        public int ScaleX { get; set; } = 100;

        public int ScaleY { get; set; } = 100;

        public int Rotation { get; set; } = 0;

        public int Spacing { get; set; } = 0;

        public StyleEncoding Encoding { get; set; } = new StyleEncoding(1, "Default");


        public InfoStyle()
        {
        }
    }


    public class StyleEncoding
    {
        public int Num { get; set; }

        public string Text { get; set; }

        public StyleEncoding(int num, string text)
        {
            Num = num;
            Text = text;
        }

        public static List<StyleEncoding> getDefaultList()
        {
            List<StyleEncoding> defaultList = new List<StyleEncoding>
            {
                new StyleEncoding(0, "ANSI"),
                new StyleEncoding(1, "Default"),
                new StyleEncoding(2, "Symbol"),
                new StyleEncoding(77, "Mac"),
                new StyleEncoding(128, "Shift_JIS"),
                new StyleEncoding(129, "Hangeul"),
                new StyleEncoding(130, "Johab"),
                new StyleEncoding(134, "GB2312"),
                new StyleEncoding(136, "Chinese BIG5"),
                new StyleEncoding(161, "Greek"),
                new StyleEncoding(162, "Turkish"),
                new StyleEncoding(163, "Vietnamese"),
                new StyleEncoding(177, "Hebrew"),
                new StyleEncoding(178, "Arabic"),
                new StyleEncoding(186, "Baltic"),
                new StyleEncoding(204, "Russian"),
                new StyleEncoding(222, "Thai"),
                new StyleEncoding(238, "East European"),
                new StyleEncoding(255, "OEM")
            };


            return defaultList;
        }

        public override string ToString()
        {
            return Num.ToString() + " - " + Text;
        }
    }
}