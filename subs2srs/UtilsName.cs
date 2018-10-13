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
using System.Text.RegularExpressions;

namespace subs2srs
{
    /// <summary>
    /// Utilities related to creation of filenames for output files based on tokens.
    /// </summary>
    public class UtilsName
    {
        private string deckName;
        private int episodeNum;
        private int totalNumEpisodes;
        private int sequenceNum;
        private DateTime startTime;
        private DateTime endTime;
        private DateTime lastTime;
        private string subs1Text;
        private string subs2Text;
        private int width;
        private int height;
        private int vobsubStreamNum;

        public int TotalNumLines { get; set; }

        public UtilsName(string deckName, int totalNumEpisodes, int totalNumLines,
            DateTime lastTime, int width, int height)
        {
            this.deckName = deckName;
            this.totalNumEpisodes = totalNumEpisodes;
            TotalNumLines = totalNumLines;
            this.lastTime = lastTime;
            this.width = width;
            this.height = height;
            vobsubStreamNum = 0;
        }

        public UtilsName(string deckName, int totalNumEpisodes, int totalNumLines,
            DateTime lastTime, int width, int height, int vobsubStreamNum)
        {
            this.deckName = deckName;
            this.totalNumEpisodes = totalNumEpisodes;
            TotalNumLines = totalNumLines;
            this.lastTime = lastTime;
            this.width = width;
            this.height = height;
            this.vobsubStreamNum = vobsubStreamNum;
        }


        /// <summary>
        /// If the provided interger where converted to a string, how many characters would it use?
        /// </summary>
        private int getMaxNecassaryLeadingZeroes(int num)
        {
            return num.ToString().Length;
        }


        /// <summary>
        /// Format tokens related to numbers that can have leading zeroes. Takes into account optional leading zeroes.
        /// </summary>
        private string formatNumberTokens(Match match)
        {
            int numZeroes = 0;
            bool numZeroesGiven = false;
            string token = "";
            string zeroString = "";
            string formatString = "";
            string finalString = "";
            int value = 0;
            DateTime diffTime = UtilsSubs.getDurationTime(startTime, endTime);
            DateTime midTime = UtilsSubs.getMidpointTime(startTime, endTime);

            // Get number of leading zeroes (if any)
            if (match.Groups[2].Success)
            {
                numZeroes = Int32.Parse(match.Groups[2].ToString());
                numZeroesGiven = true;
            }

            // Get the token
            if (match.Groups[3].Success)
            {
                token = match.Groups[3].ToString();
            }

            if (numZeroesGiven)
            {
                // Zero is special, it means use the minimum necassary number of leading zeroes based on some maximum (like the total number of lines)
                if (numZeroes == 0)
                {
                    switch (token)
                    {
                        // Start times (use the end times)
                        case "s_hour":
                            numZeroes = 1;
                            break;
                        case "s_min":
                            numZeroes = getMaxNecassaryLeadingZeroes(lastTime.TimeOfDay.Minutes); // 2;
                            break;
                        case "s_sec":
                        case "s_hsec":
                            numZeroes = 2;
                            break;
                        case "s_msec":
                            numZeroes = 3;
                            break;
                        case "s_total_hour":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalHours); // 1
                            break;
                        case "s_total_min":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMinutes); // 3
                            break;
                        case "s_total_sec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalSeconds); // 4
                            break;
                        case "s_total_hsec":
                            numZeroes = getMaxNecassaryLeadingZeroes(
                                (int) lastTime.TimeOfDay.TotalMilliseconds / 10); // 6
                            break;
                        // End times 
                        case "s_total_msec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMilliseconds); // 7
                            break;
                        case "e_hour":
                            numZeroes = 1;
                            break;
                        case "e_min":
                            numZeroes = getMaxNecassaryLeadingZeroes(lastTime.TimeOfDay.Minutes); // 2;
                            break;
                        case "e_sec":
                        case "e_hsec":
                            numZeroes = 2;
                            break;
                        case "e_msec":
                            numZeroes = 3;
                            break;
                        case "e_total_hour":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalHours); // 1
                            break;
                        case "e_total_min":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMinutes); // 3
                            break;
                        case "e_total_sec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalSeconds); // 4
                            break;
                        case "e_total_hsec":
                            numZeroes = getMaxNecassaryLeadingZeroes(
                                (int) lastTime.TimeOfDay.TotalMilliseconds / 10); // 6
                            break;
                        // Duration times (use the end times)
                        case "e_total_msec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMilliseconds); // 7
                            break;
                        case "d_hour":
                            numZeroes = 1;
                            break;
                        case "d_min":
                            numZeroes = getMaxNecassaryLeadingZeroes(lastTime.TimeOfDay.Minutes); // 2;
                            break;
                        case "d_sec":
                        case "d_hsec":
                            numZeroes = 2;
                            break;
                        case "d_msec":
                            numZeroes = 3;
                            break;
                        case "d_total_hour":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalHours); // 1
                            break;
                        case "d_total_min":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMinutes); // 3
                            break;
                        case "d_total_sec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalSeconds); // 4
                            break;
                        case "d_total_hsec":
                            numZeroes = getMaxNecassaryLeadingZeroes(
                                (int) lastTime.TimeOfDay.TotalMilliseconds / 10); // 6
                            break;
                        // Middle times (use the end times)
                        case "d_total_msec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMilliseconds); // 7
                            break;
                        case "m_hour":
                            numZeroes = 1;
                            break;
                        case "m_min":
                            numZeroes = getMaxNecassaryLeadingZeroes(lastTime.TimeOfDay.Minutes); // 2;
                            break;
                        case "m_sec":
                        case "m_hsec":
                            numZeroes = 2;
                            break;
                        case "m_msec":
                            numZeroes = 3;
                            break;
                        case "m_total_hour":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalHours); // 1
                            break;
                        case "m_total_min":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMinutes); // 3
                            break;
                        case "m_total_sec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalSeconds); // 4
                            break;
                        case "m_total_hsec":
                            numZeroes = getMaxNecassaryLeadingZeroes(
                                (int) lastTime.TimeOfDay.TotalMilliseconds / 10); // 6
                            break;
                        // The rest
                        case "m_total_msec":
                            numZeroes = getMaxNecassaryLeadingZeroes((int) lastTime.TimeOfDay.TotalMilliseconds); // 7
                            break;
                        case "episode_num":
                            numZeroes = getMaxNecassaryLeadingZeroes(totalNumEpisodes);
                            break;
                        case "sequence_num":
                        case "total_line_num":
                            numZeroes = getMaxNecassaryLeadingZeroes(TotalNumLines);
                            break;
                        case "vobsub_stream_num":
                            numZeroes = 1;
                            break;
                    }
                }

                // Limit the number of zeroes
                if (numZeroes > 9)
                {
                    numZeroes = 9;
                }

                // Create a format string that can include leading zeroes
                if (numZeroes > 0)
                {
                    zeroString += ":";
                }

                for (int i = 0; i < numZeroes; i++)
                {
                    zeroString += "0";
                }
            }

            formatString = "{0" + zeroString + "}";

            switch (token)
            {
                // Start times
                case "s_hour":
                    value = startTime.TimeOfDay.Hours;
                    break;
                case "s_min":
                    value = startTime.TimeOfDay.Minutes;
                    break;
                case "s_sec":
                    value = startTime.TimeOfDay.Seconds;
                    break;
                case "s_hsec":
                    value = startTime.TimeOfDay.Milliseconds / 10;
                    break;
                case "s_msec":
                    value = startTime.TimeOfDay.Milliseconds;
                    break;
                case "s_total_hour":
                    value = (int) startTime.TimeOfDay.TotalHours;
                    break;
                case "s_total_min":
                    value = (int) startTime.TimeOfDay.TotalMinutes;
                    break;
                case "s_total_sec":
                    value = (int) startTime.TimeOfDay.TotalSeconds;
                    break;
                case "s_total_hsec":
                    value = (int) startTime.TimeOfDay.TotalMilliseconds / 10;
                    break;
                // End times
                case "s_total_msec":
                    value = (int) startTime.TimeOfDay.TotalMilliseconds;
                    break;
                case "e_hour":
                    value = endTime.TimeOfDay.Hours;
                    break;
                case "e_min":
                    value = endTime.TimeOfDay.Minutes;
                    break;
                case "e_sec":
                    value = endTime.TimeOfDay.Seconds;
                    break;
                case "e_hsec":
                    value = endTime.TimeOfDay.Milliseconds / 10;
                    break;
                case "e_msec":
                    value = endTime.TimeOfDay.Milliseconds;
                    break;
                case "e_total_hour":
                    value = (int) endTime.TimeOfDay.TotalHours;
                    break;
                case "e_total_min":
                    value = (int) endTime.TimeOfDay.TotalMinutes;
                    break;
                case "e_total_sec":
                    value = (int) endTime.TimeOfDay.TotalSeconds;
                    break;
                case "e_total_hsec":
                    value = (int) endTime.TimeOfDay.TotalMilliseconds / 10;
                    break;
                // Duration times
                case "e_total_msec":
                    value = (int) endTime.TimeOfDay.TotalMilliseconds;
                    break;
                case "d_hour":
                    value = diffTime.TimeOfDay.Hours;
                    break;
                case "d_min":
                    value = diffTime.TimeOfDay.Minutes;
                    break;
                case "d_sec":
                    value = diffTime.TimeOfDay.Seconds;
                    break;
                case "d_hsec":
                    value = diffTime.TimeOfDay.Milliseconds / 10;
                    break;
                case "d_msec":
                    value = diffTime.TimeOfDay.Milliseconds;
                    break;
                case "d_total_hour":
                    value = (int) diffTime.TimeOfDay.TotalHours;
                    break;
                case "d_total_min":
                    value = (int) diffTime.TimeOfDay.TotalMinutes;
                    break;
                case "d_total_sec":
                    value = (int) diffTime.TimeOfDay.TotalSeconds;
                    break;
                case "d_total_hsec":
                    value = (int) diffTime.TimeOfDay.TotalMilliseconds / 10;
                    break;
                // Middle times
                case "d_total_msec":
                    value = (int) diffTime.TimeOfDay.TotalMilliseconds;
                    break;
                case "m_hour":
                    value = midTime.TimeOfDay.Hours;
                    break;
                case "m_min":
                    value = midTime.TimeOfDay.Minutes;
                    break;
                case "m_sec":
                    value = midTime.TimeOfDay.Seconds;
                    break;
                case "m_hsec":
                    value = midTime.TimeOfDay.Milliseconds / 10;
                    break;
                case "m_msec":
                    value = midTime.TimeOfDay.Milliseconds;
                    break;
                case "m_total_hour":
                    value = (int) midTime.TimeOfDay.TotalHours;
                    break;
                case "m_total_min":
                    value = (int) midTime.TimeOfDay.TotalMinutes;
                    break;
                case "m_total_sec":
                    value = (int) midTime.TimeOfDay.TotalSeconds;
                    break;
                case "m_total_hsec":
                    value = (int) midTime.TimeOfDay.TotalMilliseconds / 10;
                    break;
                // The rest
                case "m_total_msec":
                    value = (int) midTime.TimeOfDay.TotalMilliseconds;
                    break;
                case "episode_num":
                    value = episodeNum;
                    break;
                case "sequence_num":
                    value = sequenceNum;
                    break;
                case "total_line_num":
                    value = TotalNumLines;
                    break;
                case "vobsub_stream_num":
                    value = vobsubStreamNum;
                    break;
            }

            finalString = String.Format(formatString, value);

            return finalString;
        }


        /// <summary>
        /// Create a filename based on the provided format.
        /// </summary>
        public string createName(string format, int episodeNum, int sequenceNum, DateTime startTime, DateTime endTime,
            string subs1Text, string subs2Text)
        {
            string finalName = format;

            this.episodeNum = episodeNum;
            this.sequenceNum = sequenceNum;
            this.startTime = startTime;
            this.endTime = endTime;
            this.subs1Text = subs1Text;
            this.subs2Text = subs2Text;

            // Replace tokens related to numbers that can have leading zeroes
            finalName = Regex.Replace(finalName,
                @"\$\{((\d*):)?(" +
                "s_hour|s_min|s_sec|s_hsec|s_msec|s_total_hour|s_total_min|s_total_sec|s_total_hsec|s_total_msec|" +
                "e_hour|e_min|e_sec|e_hsec|e_msec|e_total_hour|e_total_min|e_total_sec|e_total_hsec|e_total_msec|" +
                "d_hour|d_min|d_sec|d_hsec|d_msec|d_total_hour|d_total_min|d_total_sec|d_total_hsec|d_total_msec|" +
                "m_hour|m_min|m_sec|m_hsec|m_msec|m_total_hour|m_total_min|m_total_sec|m_total_hsec|m_total_msec|" +
                "episode_num|sequence_num|total_line_num|vobsub_stream_num" +
                @")\}", new MatchEvaluator(formatNumberTokens), RegexOptions.Compiled);

            if (width > -1)
            {
                // Replace tokens related to numbers that don't have leading zeroes
                finalName = finalName.Replace("${width}", subs2Text);
                finalName = finalName.Replace("${height}", subs2Text);
            }

            // Replace tokens related to strings
            finalName = finalName.Replace("${deck_name}", deckName);
            finalName = finalName.Replace("${subs1_line}", subs1Text);
            finalName = finalName.Replace("${subs2_line}", subs2Text);

            // Escape chars
            finalName = finalName.Replace("${cr}", "\r");
            finalName = finalName.Replace("${lf}", "\n");
            finalName = finalName.Replace("${tab}", "\t");

            return finalName;
        }
    }
}