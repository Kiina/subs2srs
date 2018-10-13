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
    /// Represents FFmpeg progress.
    /// </summary>
    public class InfoFFmpegProgress
    {
        /// <summary>
        /// The current frame being processed.
        /// </summary>
        public int Frame { get; set; }


        /// <summary>
        /// The Frames Per Second the video is being encoded at.
        /// </summary>
        public int FPS { get; set; }


        /// <summary>
        /// Quantizer.
        /// </summary>
        public double Q { get; set; }


        /// <summary>
        /// File size.
        /// </summary>
        public int FileSize { get; set; }


        /// <summary>
        /// The timestamp of the frame currently being processed.
        /// </summary>
        public DateTime Time { get; set; }


        /// <summary>
        /// The (average?) bitrate being used to encode the file.
        /// </summary>
        public double Bitrate { get; set; }


        public bool VideoProgress { get; set; }


        public InfoFFmpegProgress()
        {
            Frame = 0;
            FPS = 0;
            Q = 0;
            FileSize = 0;
            Time = new DateTime();
            Bitrate = 0;
            VideoProgress = false;
        }

        /// <summary>
        /// Parse the output of FFmpeg and extract progress information.
        /// </summary>
        public bool parseFFmpegProgress(string text)
        {
            // frame= 1499 fps= 62 q=2.0 size=    6884kB time=00:01:02.43 bitrate= 903.2kbits/s
            // or 
            // size=    6884kB time=00:01:02.43 bitrate= 903.2kbits/s
            Match match = Regex.Match(text,
                @"^(?:frame=\s*?(?<Frame>\d+?)\s*?fps=\s*?(?<FPS>\d+?)\s*q=(?<Q>\d.*?)\s*?)?" +
                @"size=\s*(?<Size>\d+?)kB\s*?time=(?<Hours>\d\d):(?<Minutes>\d\d):(?<Seconds>\d\d).(?<CentiSeconds>\d\d)\s*?bitrate=\s*?(?<Bitrate>\d.*?)kbits/s\s*$",
                RegexOptions.Compiled);

            if (!match.Success)
            {
                return false;
            }

            try
            {
                if (match.Groups["Frame"].Success)
                {
                    VideoProgress = true;
                    Frame = Convert.ToInt32(match.Groups["Frame"].ToString().Trim());
                    FPS = Convert.ToInt32(match.Groups["FPS"].ToString().Trim());
                    Q = Convert.ToDouble(match.Groups["Q"].ToString().Trim());
                }
                else
                {
                    VideoProgress = false;
                }

                FileSize = Convert.ToInt32(match.Groups["Size"].ToString().Trim());
                Time = new DateTime();
                Time = Time.AddHours(Convert.ToInt32(match.Groups["Hours"].ToString().Trim()));
                Time = Time.AddMinutes(Convert.ToInt32(match.Groups["Minutes"].ToString().Trim()));
                Time = Time.AddSeconds(Convert.ToInt32(match.Groups["Seconds"].ToString().Trim()));
                Time = Time.AddMilliseconds(10 * Convert.ToInt32(match.Groups["CentiSeconds"].ToString().Trim()));
                Bitrate = Convert.ToDouble(match.Groups["Bitrate"].ToString().Trim());
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}