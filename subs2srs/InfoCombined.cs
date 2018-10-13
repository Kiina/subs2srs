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

using System;

namespace subs2srs
{
    /// <summary>
    /// Represents paired lines: Subs1 and it's corresponding Sub2.
    /// </summary>
    [Serializable]
    public class InfoCombined
    {
        private bool active;
        private bool onlyNeededForContext;

        public InfoLine Subs1 { get; }

        public InfoLine Subs2 { get; }

        /// <summary>
        /// Is the line active? (That is, will it be processed?)
        /// </summary>
        public bool Active
        {
            get => active;
            set => active = value;
        }

        /// <summary>
        /// Is the line only needed for context information?
        /// If true, Active is false for this line.
        /// </summary>
        public bool OnlyNeededForContext
        {
            get => onlyNeededForContext;
            set => onlyNeededForContext = value;
        }


        public InfoCombined(InfoLine subs1, InfoLine subs2)
        {
            Subs1 = subs1;
            Subs2 = subs2;
            active = true;
            onlyNeededForContext = false;
        }

        public InfoCombined(InfoLine subs1, InfoLine subs2, bool active)
        {
            Subs1 = subs1;
            Subs2 = subs2;
            this.active = active;
            onlyNeededForContext = false;
        }


        public override string ToString()
        {
            return $"{active}, {onlyNeededForContext}, {Subs1.StartTime}, {Subs1.EndTime}";
        }
    }
}