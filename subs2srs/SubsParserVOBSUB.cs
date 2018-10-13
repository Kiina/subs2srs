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
using System.Collections.Generic;
using System.IO;

namespace subs2srs
{
    /// <summary>
    /// Parser for VOBSUB (.idx/.sub) files.
    /// </summary>
    class SubsParserVOBSUB : SubsParser
    {
        public SubsParserVOBSUB(WorkerVars workerVars, string file, int stream, int episode, int subsNum)
        {
            WorkerVars = workerVars;
            File = file;
            Stream = stream;
            Episode = episode;
            SubsNum = subsNum;
        }


        /// <summary>
        /// Parse the subtitle file and return a list of lines.
        /// </summary>
        public override List<InfoLine> parse()
        {
            List<InfoLine> lineInfos = new List<InfoLine>(2000);

            SubtitleCreator.SUP.reset();
            SubtitleCreator.SUP sup = SubtitleCreator.SUP.Instance;

            // Load in the .idx/.sub file (takes a while)
            sup.Filename = File;

            if (Settings.Instance.VobSubColors.Enabled)
            {
                sup.ReadSUP(Stream, Settings.Instance.VobSubColors.Colors,
                    Settings.Instance.VobSubColors.TransparencyEnabled);
            }
            else
            {
                sup.ReadSUP(Stream, null, null);
            }

            UtilsName name = new UtilsName(Settings.Instance.DeckName, 0, 0, new DateTime(),
                Settings.Instance.VideoClips.Size.Width, Settings.Instance.VideoClips.Size.Height);

            for (int i = 0; i < sup.GetNoOfSubtitles(); i++)
            {
                DateTime startTime = sup.GetStartTime(i);
                DateTime endTime = sup.GetEndTime(i);

                // Used for the filename and the desision to save the image file.
                // Not used to set the time of the InfoLine because the shift is
                // also applied in WorkerSubs
                DateTime shiftedStartTime = sup.GetStartTime(i);
                DateTime shiftedEndTime = sup.GetEndTime(i);

                if (Settings.Instance.TimeShiftEnabled)
                {
                    shiftedStartTime =
                        UtilsSubs.shiftTiming(shiftedStartTime, Settings.Instance.Subs[SubsNum - 1].TimeShift);
                    shiftedEndTime =
                        UtilsSubs.shiftTiming(shiftedEndTime, Settings.Instance.Subs[SubsNum - 1].TimeShift);
                }

                string bitmapFile =
                    $"{Settings.Instance.DeckName}_{Episode:000.}_Stream_{Stream:00.}_Subs{SubsNum}_{(int) shiftedStartTime.TimeOfDay.TotalMinutes:000.}.{(int) shiftedStartTime.TimeOfDay.Seconds:00.}.{(int) (shiftedStartTime.TimeOfDay.Milliseconds * 0.1):00.}-{(int) shiftedEndTime.TimeOfDay.TotalMinutes:000.}.{(int) shiftedEndTime.TimeOfDay.Seconds:00.}.{(int) (shiftedEndTime.TimeOfDay.Milliseconds * 0.1):00.}.png";

                DateTime spanStart = Settings.Instance.SpanStart;
                DateTime spanEnd = Settings.Instance.SpanEnd;

                // Create a image file for each line of dialog 
                if (WorkerVars.ProcessingType ==
                    WorkerVars.SubsProcessingType.Preview // Always save the image when previewing
                    || !Settings.Instance.SpanEnabled // Always save the image when span is not enabled
                    || shiftedStartTime >= spanStart && shiftedEndTime <= spanEnd
                ) // When span is enabled, only save the images that are within the span
                {
                    string imageSavePath = Path.Combine(WorkerVars.MediaDir, bitmapFile);
                    sup.GetBitmap(i).Save(imageSavePath, System.Drawing.Imaging.ImageFormat.Png);
                }

                string prefixStr = name.createName(ConstantSettings.SrsVobsubFilenamePrefix, 0, 0, new DateTime(),
                    new DateTime(), "", "");
                string suffixStr = name.createName(ConstantSettings.SrsVobsubFilenameSuffix, 0, 0, new DateTime(),
                    new DateTime(), "", "");

                // Set the line of dialog to the bitmap file
                string text = $"{prefixStr}{bitmapFile}{suffixStr}"; // {2}

                InfoLine info = new InfoLine(startTime, endTime, text);
                lineInfos.Add(info);
            }

            lineInfos.Sort();

            return lineInfos;
        }
    }
}