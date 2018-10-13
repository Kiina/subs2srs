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
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;

namespace subs2srs
{
    public static class PrefDefaults
    {
        public const int MainWindowWidth = 614;
        public const int MainWindowHeight = 630;
        public const bool DefaultEnableAudioClipGeneration = true;
        public const bool DefaultEnableSnapshotsGeneration = true;
        public const bool DefaultEnableVideoClipsGeneration = false;
        public const string VideoPlayer = "";
        public const string VideoPlayerArgs = "";
        public const bool ReencodeBeforeSplittingAudio = false;
        public const bool EnableLogging = true;
        public const string AudioNormalizeArgs = "/f /q /r /k";
        public const int LongClipWarningSeconds = 10;
        public const int DefaultAudioClipBitrate = 128;
        public const bool DefaultAudioNormalize = false;
        public const int DefaultVideoClipVideoBitrate = 800;
        public const int DefaultVideoClipAudioBitrate = 128;
        public const bool DefaultIphoneSupport = false;
        public const string DefaultEncodingSubs1 = "utf-8";
        public const string DefaultEncodingSubs2 = "utf-8";
        public const int DefaultContextNumLeading = 0;
        public const int DefaultContextNumTrailing = 0;
        public const int DefaultContextLeadingRange = 15;
        public const int DefaultContextTrailingRange = 15;
        public const string DefaultFileBrowserStartDir = "";
        public const bool DefaultRemoveStyledLinesSubs1 = true;
        public const bool DefaultRemoveStyledLinesSubs2 = true;
        public const bool DefaultRemoveNoCounterpartSubs1 = true;
        public const bool DefaultRemoveNoCounterpartSubs2 = true;
        public const string DefaultIncludeTextSubs1 = "";
        public const string DefaultIncludeTextSubs2 = "";
        public const string DefaultExcludeTextSubs1 = "";
        public const string DefaultExcludeTextSubs2 = "";
        public const bool DefaultExcludeDuplicateLinesSubs1 = false;
        public const bool DefaultExcludeDuplicateLinesSubs2 = false;
        public const bool DefaultExcludeLinesFewerThanCharsSubs1 = false;
        public const bool DefaultExcludeLinesFewerThanCharsSubs2 = false;
        public const int DefaultExcludeLinesFewerThanCharsNumSubs1 = 8;
        public const int DefaultExcludeLinesFewerThanCharsNumSubs2 = 8;
        public const bool DefaultExcludeLinesShorterThanMsSubs1 = false;
        public const bool DefaultExcludeLinesShorterThanMsSubs2 = false;
        public const int DefaultExcludeLinesShorterThanMsNumSubs1 = 800;
        public const int DefaultExcludeLinesShorterThanMsNumSubs2 = 800;
        public const bool DefaultExcludeLinesLongerThanMsSubs1 = false;
        public const bool DefaultExcludeLinesLongerThanMsSubs2 = false;
        public const int DefaultExcludeLinesLongerThanMsNumSubs1 = 5000;
        public const int DefaultExcludeLinesLongerThanMsNumSubs2 = 5000;
        public const bool DefaultJoinSentencesSubs1 = true;
        public const bool DefaultJoinSentencesSubs2 = true;
        public const string DefaultJoinSentencesCharListSubs1 = ",、→";
        public const string DefaultJoinSentencesCharListSubs2 = ",、→";
        public const string SrsFilenameFormat = "${deck_name}.tsv";
        public const string SrsDelimiter = "\t";
        public const string SrsTagFormat = "${deck_name}_${0:episode_num}";

        public const string SrsSequenceMarkerFormat =
            "${0:episode_num}_${0:sequence_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}";

        public const string SrsAudioFilenamePrefix = "[sound:";
        public const string SrsAudioFilenameSuffix = "]";
        public const string SrsSnapshotFilenamePrefix = "<img src=\"";
        public const string SrsSnapshotFilenameSuffix = "\">";
        public const string SrsVideoFilenamePrefix = "[sound:";
        public const string SrsVideoFilenameSuffix = "]";
        public const string SrsSubs1Format = "${subs1_line}";
        public const string SrsSubs2Format = "${subs2_line}";
        public const string SrsVobsubFilenamePrefix = "<img src=\"";

        public const string SrsVobsubFilenameFormat =
            "${deck_name}_${0:episode_num}_Stream_${0:stream_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}-${0:e_total_hour}.${0:e_min}.${0:e_sec}.${0:e_msec}.png";

        public const string SrsVobsubFilenameSuffix = "\">";

        public const string AudioFilenameFormat =
            "${deck_name}_${0:episode_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}-${0:e_total_hour}.${0:e_min}.${0:e_sec}.${0:e_msec}.mp3";

        public const string SnapshotFilenameFormat =
            "${deck_name}_${0:episode_num}_${0:m_total_hour}.${0:m_min}.${0:m_sec}.${0:m_msec}.jpg";

        public const string VideoFilenameFormat =
            "${deck_name}_${0:episode_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}-${0:e_total_hour}.${0:e_min}.${0:e_sec}.${0:e_msec}";

        public const string VobsubFilenameFormat =
            "${deck_name}_${0:episode_num}_Stream_${0:stream_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}-${0:e_total_hour}.${0:e_min}.${0:e_sec}.${0:e_msec}.png";

        public const string AudioId3Artist = "${deck_name}";
        public const string AudioId3Album = "${deck_name}_${0:episode_num}";

        public const string AudioId3Title =
            "${deck_name}_${0:episode_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}-${0:e_total_hour}.${0:e_min}.${0:e_sec}.${0:e_msec}";

        public const string AudioId3Genre = "Speech";
        public const string AudioId3Lyrics = "${subs1_line} ${subs2_line}";

        public const string ExtractMediaAudioFilenameFormat =
            "${deck_name}_${0:episode_num}_${0:s_total_hour}.${0:s_min}.${0:s_sec}.${0:s_msec}-${0:e_total_hour}.${0:e_min}.${0:e_sec}.${0:e_msec}.mp3";

        public const string ExtractMediaLyricsSubs1Format = "[${2:s_total_min}:${2:s_sec}.${2:s_hsec}] ${subs1_line}";
        public const string ExtractMediaLyricsSubs2Format = "[${2:s_total_min}:${2:s_sec}.${2:s_hsec}] ${subs2_line}";
        public const string DuelingSubtitleFilenameFormat = "${deck_name}_${0:episode_num}.ass";
        public const string DuelingQuickRefFilenameFormat = "${deck_name}_${0:episode_num}.txt";

        public const string DuelingQuickRefSubs1Format =
            "[${0:s_total_hour}:${0:s_min}:${0:s_sec}.${0:s_hsec}]  ${subs1_line}";

        public const string DuelingQuickRefSubs2Format =
            "[${0:s_total_hour}:${0:s_min}:${0:s_sec}.${0:s_hsec}]  ${subs2_line}\n";
    }


    // Procedure for creating a new Constant Settings that can be set in the Preferences dialog.
    // 1) Create a new entry in preferences.txt
    // 2) Create a default for the setting in PrefDefaults (above).
    // 3) Create the setting in ConstantSettings (var and property).
    // 4) Add setting to PrefIO.read.
    // 5) Add setting to DialogPref constructor.
    // 6) Add setting to DialogPref buttonOK_Click.
    // 7) Add setting to Logger.writeSettingsToLog.
    // 8) For GUI settings, add to FormMain.readPreferencesFile.


    public static class ConstantSettings
    {
        private static string pathFFmpeg = Path.Combine("Utils", "ffmpeg");
        private static string pathFFmpegFull = UtilsCommon.getAppDir(true) + pathFFmpeg;

        // Preferences file stuff

        public static string SaveExt { get; } = "s2s";

        public static string HelpPage { get; } = "http://subs2srs.sourceforge.net/";

        public static string LogDir { get; } = UtilsCommon.getAppDir(true) + "Logs" + Path.DirectorySeparatorChar;

        public static int MaxLogFiles { get; } = 10;

        public static string ExeFFmpeg { get; } = @"ffmpeg.exe";

        public static string PathFFmpegExe { get; } = pathFFmpeg + Path.DirectorySeparatorChar + ExeFFmpeg;

        public static string PathFFmpegFullExe { get; } = Path.Combine(pathFFmpegFull, ExeFFmpeg);

        public static string PathFFmpegPresetsFull { get; } = Path.Combine(pathFFmpegFull, "presets");

        public static string TempImageFilename { get; } = $"~subs2srs_temp_{Guid.NewGuid().ToString()}.jpg";

        public static string TempVideoFilename { get; } = $"~subs2srs_temp_{Guid.NewGuid().ToString()}";

        public static string TempAudioFilename { get; } = $"~subs2srs_temp_{Guid.NewGuid().ToString()}.mp3";

        public static string TempAudioPreviewFilename { get; } = $"~subs2srs_temp_{Guid.NewGuid().ToString()}.wav";

        public static string TempPreviewDirName { get; } = $"~subs2srs_preview_{Guid.NewGuid().ToString()}";

        public static string TempMkvExtractSubs1Filename { get; } =
            $"~subs2srs_mkv_extract_subs1_{Guid.NewGuid().ToString()}";

        public static string TempMkvExtractSubs2Filename { get; } =
            $"~subs2srs_mkv_extract_subs2_{Guid.NewGuid().ToString()}";

        public static string NormalizeAudioExe { get; } = "mp3gain.exe";

        public static string PathNormalizeAudioExeRel { get; } = String.Format("Utils{0}mp3gain{0}{1}",
            Path.DirectorySeparatorChar, NormalizeAudioExe);

        public static string PathNormalizeAudioExeFull { get; } =
            $"{UtilsCommon.getAppDir(true)}{PathNormalizeAudioExeRel}";

        public static string PathSubsReTimerFull { get; } = String.Format("{0}Utils{1}SubsReTimer{1}SubsReTimer.exe",
            UtilsCommon.getAppDir(true), Path.DirectorySeparatorChar);

        public static string PathMkvDirRel { get; } =
            String.Format("Utils{0}mkvtoolnix{0}", Path.DirectorySeparatorChar);

        public static string PathMkvDirFull { get; } = String.Format("{0}Utils{1}mkvtoolnix{1}",
            UtilsCommon.getAppDir(true), Path.DirectorySeparatorChar);

        public static string PathMkvInfoExeRel { get; } = PathMkvDirRel + "mkvinfo.exe";

        public static string PathMkvInfoExeFull { get; } = PathMkvDirFull + "mkvinfo.exe";

        public static string PathMkvExtractExeRel { get; } = PathMkvDirRel + "mkvextract.exe";

        public static string PathMkvExtractExeFull { get; } = PathMkvDirFull + "mkvextract.exe";

        public static string SettingsFilename { get; } = "preferences.txt";

        public static int MainWindowWidth { get; set; } = PrefDefaults.MainWindowWidth;

        public static int MainWindowHeight { get; set; } = PrefDefaults.MainWindowHeight;

        public static bool DefaultEnableAudioClipGeneration { get; set; } =
            PrefDefaults.DefaultEnableAudioClipGeneration;

        public static bool DefaultEnableSnapshotsGeneration { get; set; } =
            PrefDefaults.DefaultEnableSnapshotsGeneration;

        public static bool DefaultEnableVideoClipsGeneration { get; set; } =
            PrefDefaults.DefaultEnableVideoClipsGeneration;

        public static string VideoPlayer { get; set; } = PrefDefaults.VideoPlayer;

        public static string VideoPlayerArgs { get; set; } = PrefDefaults.VideoPlayerArgs;

        public static bool ReencodeBeforeSplittingAudio { get; set; } = PrefDefaults.ReencodeBeforeSplittingAudio;

        public static bool EnableLogging { get; set; } = PrefDefaults.EnableLogging;

        public static string AudioNormalizeArgs { get; set; } = PrefDefaults.AudioNormalizeArgs;

        public static int LongClipWarningSeconds { get; set; } = PrefDefaults.LongClipWarningSeconds;

        public static int DefaultAudioClipBitrate { get; set; } = PrefDefaults.DefaultAudioClipBitrate;

        public static bool DefaultAudioNormalize { get; set; } = PrefDefaults.DefaultAudioNormalize;

        public static int DefaultVideoClipVideoBitrate { get; set; } = PrefDefaults.DefaultVideoClipVideoBitrate;

        public static int DefaultVideoClipAudioBitrate { get; set; } = PrefDefaults.DefaultVideoClipAudioBitrate;

        public static bool DefaultIphoneSupport { get; set; } = PrefDefaults.DefaultIphoneSupport;

        public static string DefaultEncodingSubs1 { get; set; } = PrefDefaults.DefaultEncodingSubs1;

        public static string DefaultEncodingSubs2 { get; set; } = PrefDefaults.DefaultEncodingSubs2;

        public static int DefaultContextNumLeading { get; set; } = PrefDefaults.DefaultContextNumLeading;

        public static int DefaultContextNumTrailing { get; set; } = PrefDefaults.DefaultContextNumTrailing;

        public static int DefaultContextLeadingRange { get; set; } = PrefDefaults.DefaultContextLeadingRange;

        public static int DefaultContextTrailingRange { get; set; } = PrefDefaults.DefaultContextTrailingRange;

        public static string DefaultFileBrowserStartDir { get; set; } = PrefDefaults.DefaultFileBrowserStartDir;

        public static bool DefaultRemoveStyledLinesSubs1 { get; set; } = PrefDefaults.DefaultRemoveStyledLinesSubs1;

        public static bool DefaultRemoveStyledLinesSubs2 { get; set; } = PrefDefaults.DefaultRemoveStyledLinesSubs2;

        public static bool DefaultRemoveNoCounterpartSubs1 { get; set; } = PrefDefaults.DefaultRemoveNoCounterpartSubs1;

        public static bool DefaultRemoveNoCounterpartSubs2 { get; set; } = PrefDefaults.DefaultRemoveNoCounterpartSubs2;

        public static string DefaultIncludeTextSubs1 { get; set; } = PrefDefaults.DefaultIncludeTextSubs1;

        public static string DefaultIncludeTextSubs2 { get; set; } = PrefDefaults.DefaultIncludeTextSubs2;

        public static string DefaultExcludeTextSubs1 { get; set; } = PrefDefaults.DefaultExcludeTextSubs1;

        public static string DefaultExcludeTextSubs2 { get; set; } = PrefDefaults.DefaultExcludeTextSubs2;

        public static bool DefaultExcludeLinesFewerThanCharsSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeLinesFewerThanCharsSubs1;

        public static bool DefaultExcludeLinesFewerThanCharsSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeLinesFewerThanCharsSubs2;

        public static int DefaultExcludeLinesFewerThanCharsNumSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeLinesFewerThanCharsNumSubs1;

        public static int DefaultExcludeLinesFewerThanCharsNumSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeLinesFewerThanCharsNumSubs2;

        public static bool DefaultExcludeLinesShorterThanMsSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeLinesShorterThanMsSubs1;

        public static bool DefaultExcludeLinesShorterThanMsSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeLinesShorterThanMsSubs2;

        public static int DefaultExcludeLinesShorterThanMsNumSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeLinesShorterThanMsNumSubs1;

        public static int DefaultExcludeLinesShorterThanMsNumSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeLinesShorterThanMsNumSubs2;

        public static bool DefaultExcludeLinesLongerThanMsSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeLinesLongerThanMsSubs1;

        public static bool DefaultExcludeLinesLongerThanMsSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeLinesLongerThanMsSubs2;

        public static int DefaultExcludeLinesLongerThanMsNumSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeLinesLongerThanMsNumSubs1;

        public static int DefaultExcludeLinesLongerThanMsNumSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeLinesLongerThanMsNumSubs2;

        public static bool DefaultJoinSentencesSubs1 { get; set; } = PrefDefaults.DefaultJoinSentencesSubs1;

        public static bool DefaultJoinSentencesSubs2 { get; set; } = PrefDefaults.DefaultJoinSentencesSubs2;

        public static string DefaultJoinSentencesCharListSubs1 { get; set; } =
            PrefDefaults.DefaultJoinSentencesCharListSubs1;

        public static string DefaultJoinSentencesCharListSubs2 { get; set; } =
            PrefDefaults.DefaultJoinSentencesCharListSubs2;

        public static bool DefaultExcludeDuplicateLinesSubs1 { get; set; } =
            PrefDefaults.DefaultExcludeDuplicateLinesSubs1;

        public static bool DefaultExcludeDuplicateLinesSubs2 { get; set; } =
            PrefDefaults.DefaultExcludeDuplicateLinesSubs2;

        public static string SrsFilenameFormat { get; set; } = PrefDefaults.SrsFilenameFormat;

        public static string SrsDelimiter { get; set; } = PrefDefaults.SrsDelimiter;

        public static string SrsTagFormat { get; set; } = PrefDefaults.SrsTagFormat;

        public static string SrsSequenceMarkerFormat { get; set; } = PrefDefaults.SrsSequenceMarkerFormat;

        public static string SrsAudioFilenamePrefix { get; set; } = PrefDefaults.SrsAudioFilenamePrefix;

        public static string SrsAudioFilenameSuffix { get; set; } = PrefDefaults.SrsAudioFilenameSuffix;

        public static string SrsSnapshotFilenamePrefix { get; set; } = PrefDefaults.SrsSnapshotFilenamePrefix;

        public static string SrsSnapshotFilenameSuffix { get; set; } = PrefDefaults.SrsSnapshotFilenameSuffix;

        public static string SrsVideoFilenamePrefix { get; set; } = PrefDefaults.SrsVideoFilenamePrefix;

        public static string SrsVideoFilenameSuffix { get; set; } = PrefDefaults.SrsVideoFilenameSuffix;

        public static string SrsSubs1Format { get; set; } = PrefDefaults.SrsSubs1Format;

        public static string SrsSubs2Format { get; set; } = PrefDefaults.SrsSubs2Format;

        public static string SrsVobsubFilenamePrefix { get; set; } = PrefDefaults.SrsVobsubFilenamePrefix;

        public static string SrsVobsubFilenameSuffix { get; set; } = PrefDefaults.SrsVobsubFilenameSuffix;

        public static string AudioFilenameFormat { get; set; } = PrefDefaults.AudioFilenameFormat;

        public static string SnapshotFilenameFormat { get; set; } = PrefDefaults.SnapshotFilenameFormat;

        public static string VideoFilenameFormat { get; set; } = PrefDefaults.VideoFilenameFormat;

        public static string VobsubFilenameFormat { get; set; } = PrefDefaults.VobsubFilenameFormat;

        public static string AudioId3Artist { get; set; } = PrefDefaults.AudioId3Artist;

        public static string AudioId3Album { get; set; } = PrefDefaults.AudioId3Album;

        public static string AudioId3Title { get; set; } = PrefDefaults.AudioId3Title;

        public static string AudioId3Genre { get; set; } = PrefDefaults.AudioId3Genre;

        public static string AudioId3Lyrics { get; set; } = PrefDefaults.AudioId3Lyrics;

        public static string ExtractMediaAudioFilenameFormat { get; set; } =
            PrefDefaults.ExtractMediaAudioFilenameFormat;

        public static string ExtractMediaLyricsSubs1Format { get; set; } = PrefDefaults.ExtractMediaLyricsSubs1Format;

        public static string ExtractMediaLyricsSubs2Format { get; set; } = PrefDefaults.ExtractMediaLyricsSubs2Format;

        public static string DuelingSubtitleFilenameFormat { get; set; } = PrefDefaults.DuelingSubtitleFilenameFormat;

        public static string DuelingQuickRefFilenameFormat { get; set; } = PrefDefaults.DuelingQuickRefFilenameFormat;

        public static string DuelingQuickRefSubs1Format { get; set; } = PrefDefaults.DuelingQuickRefSubs1Format;

        public static string DuelingQuickRefSubs2Format { get; set; } = PrefDefaults.DuelingQuickRefSubs2Format;
    }


    [Serializable]
    public class SubSettings
    {
        private string filePattern; // File (can include wildcards: * and ?)
        [NonSerialized()] private string[] files;
        private InfoStream vobsubStream;
        private bool timingsEnabled;
        private int timeShift; // ms
        private string[] includedWords;
        private string[] excludedWords;
        private bool removeNoCounterpart;
        private bool removeStyledLines; // Styled-lined begin with '{'
        private bool excludeDuplicateLinesEnabled;
        private bool excludeFewerEnabled;
        private int excludeFewerCount; // Number of chars
        private bool excludeShorterThanTimeEnabled;
        private int excludeShorterThanTime; // ms
        private bool excludeLongerThanTimeEnabled;
        private int excludeLongerThanTime; // ms
        private bool joinSentencesEnabled;
        private string joinSentencesCharList;
        private bool actorsEnabled;
        private string encoding;

        public string FilePattern
        {
            get => filePattern;
            set => filePattern = value;
        }

        public string[] Files
        {
            get => files;
            set => files = value;
        }

        public InfoStream VobsubStream
        {
            get => vobsubStream;
            set => vobsubStream = value;
        }

        public bool TimingsEnabled
        {
            get => timingsEnabled;
            set => timingsEnabled = value;
        }

        public int TimeShift
        {
            get => timeShift;
            set => timeShift = value;
        }

        public string[] IncludedWords
        {
            get => includedWords;
            set => includedWords = value;
        }

        public string[] ExcludedWords
        {
            get => excludedWords;
            set => excludedWords = value;
        }

        public bool RemoveNoCounterpart
        {
            get => removeNoCounterpart;
            set => removeNoCounterpart = value;
        }

        public bool RemoveStyledLines
        {
            get => removeStyledLines;
            set => removeStyledLines = value;
        }

        public bool ExcludeDuplicateLinesEnabled
        {
            get => excludeDuplicateLinesEnabled;
            set => excludeDuplicateLinesEnabled = value;
        }

        public bool ExcludeFewerEnabled
        {
            get => excludeFewerEnabled;
            set => excludeFewerEnabled = value;
        }

        public int ExcludeFewerCount
        {
            get => excludeFewerCount;
            set => excludeFewerCount = value;
        }

        public bool ExcludeShorterThanTimeEnabled
        {
            get => excludeShorterThanTimeEnabled;
            set => excludeShorterThanTimeEnabled = value;
        }

        public int ExcludeShorterThanTime
        {
            get => excludeShorterThanTime;
            set => excludeShorterThanTime = value;
        }

        public bool ExcludeLongerThanTimeEnabled
        {
            get => excludeLongerThanTimeEnabled;
            set => excludeLongerThanTimeEnabled = value;
        }

        public int ExcludeLongerThanTime
        {
            get => excludeLongerThanTime;
            set => excludeLongerThanTime = value;
        }

        public bool JoinSentencesEnabled
        {
            get => joinSentencesEnabled;
            set => joinSentencesEnabled = value;
        }

        public string JoinSentencesCharList
        {
            get => joinSentencesCharList;
            set => joinSentencesCharList = value;
        }

        public bool ActorsEnabled
        {
            get => actorsEnabled;
            set => actorsEnabled = value;
        }

        public string Encoding
        {
            get => encoding;
            set => encoding = value;
        }

        public SubSettings()
        {
            filePattern = "";
            vobsubStream = null;
            timingsEnabled = false;
            timeShift = 0;
            includedWords = new string[0];
            excludedWords = new string[0];
            removeNoCounterpart = true;
            removeStyledLines = true;
            excludeDuplicateLinesEnabled = false;
            excludeFewerEnabled = false;
            excludeFewerCount = 8;
            excludeShorterThanTimeEnabled = false;
            excludeShorterThanTime = 800;
            excludeLongerThanTimeEnabled = false;
            excludeLongerThanTime = 5000;
            joinSentencesEnabled = true;
            joinSentencesCharList = ",、→";
            actorsEnabled = false;
            encoding = "utf-8";
            files = new string[0];
        }
    }

    [Serializable]
    public class ImageSize
    {
        private int width; // Width in pixels
        private int height; // Hieght in pixels

        public int Width
        {
            get => width;
            set => width = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public ImageSize()
        {
            width = 0;
            height = 0;
        }

        public ImageSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
    }

    [Serializable]
    public class ImageCrop
    {
        private int top;
        private int bottom;
        private int left;
        private int right;

        public int Top
        {
            get => top;
            set => top = value;
        }

        public int Bottom
        {
            get => bottom;
            set => bottom = value;
        }

        public int Left
        {
            get => left;
            set => left = value;
        }

        public int Right
        {
            get => right;
            set => right = value;
        }

        public ImageCrop()
        {
            top = 0;
            bottom = 0;
            left = 0;
            right = 0;
        }

        public ImageCrop(int top, int bottom, int left, int right)
        {
            this.top = top;
            this.bottom = bottom;
            this.left = left;
            this.right = right;
        }
    }


    [Serializable]
    public class VideoClips
    {
        private bool enabled;
        private string dir;
        private InfoStream audioStream;
        [NonSerialized()] private string[] files;
        ImageSize size; // Width Must be a multiple of 16, Height must be a multiple of 2
        private int bitrateVideo; // kb/s
        private int bitrateAudio; // kb/s
        private bool padEnabled;
        private int padStart; // ms
        private int padEnd; // ms
        private ImageCrop crop; // Pixels, must be a multiple of 2
        private bool iPodSupport;

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string FilePattern
        {
            get => dir;
            set => dir = value;
        }

        public InfoStream AudioStream
        {
            get => audioStream;
            set => audioStream = value;
        }

        public string[] Files
        {
            get => files;
            set => files = value;
        }

        public ImageSize Size
        {
            get => size;
            set => size = value;
        }

        public int BitrateVideo
        {
            get => bitrateVideo;
            set => bitrateVideo = value;
        }

        public int BitrateAudio
        {
            get => bitrateAudio;
            set => bitrateAudio = value;
        }

        public bool PadEnabled
        {
            get => padEnabled;
            set => padEnabled = value;
        }

        public int PadStart
        {
            get => padStart;
            set => padStart = value;
        }

        public int PadEnd
        {
            get => padEnd;
            set => padEnd = value;
        }

        public ImageCrop Crop
        {
            get => crop;
            set => crop = value;
        }

        public bool IPodSupport
        {
            get => iPodSupport;
            set => iPodSupport = value;
        }

        public VideoClips()
        {
            enabled = false;
            dir = "";
            audioStream = null;
            files = new string[0];
            size = new ImageSize((int) (720 / 3), (int) (480 / 3));
            bitrateVideo = 700;
            bitrateAudio = 128;
            padEnabled = false;
            padStart = 250;
            padEnd = 250;
            crop = new ImageCrop(0, 0, 0, 0);
            iPodSupport = false;
        }
    }


    [Serializable]
    public class AudioClips
    {
        private bool enabled;
        private string dir;
        [NonSerialized()] private string[] files;
        private bool padEnabled;
        private int padStart; // ms
        private int padEnd; // ms
        private int bitrate; // kb/s
        private bool useAudioFromVideo;
        private bool useExistingAudio;
        private bool normalize;

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string filePattern
        {
            get => dir;
            set => dir = value;
        }

        public string[] Files
        {
            get => files;
            set => files = value;
        }

        public bool PadEnabled
        {
            get => padEnabled;
            set => padEnabled = value;
        }

        public int PadStart
        {
            get => padStart;
            set => padStart = value;
        }

        public int PadEnd
        {
            get => padEnd;
            set => padEnd = value;
        }

        public int Bitrate
        {
            get => bitrate;
            set => bitrate = value;
        }

        public bool UseAudioFromVideo
        {
            get => useAudioFromVideo;
            set => useAudioFromVideo = value;
        }

        public bool UseExistingAudio
        {
            get => useExistingAudio;
            set => useExistingAudio = value;
        }

        public bool Normalize
        {
            get => normalize;
            set => normalize = value;
        }

        public AudioClips()
        {
            enabled = true;
            dir = "";
            files = new string[0];
            padEnabled = false;
            padStart = 250;
            padEnd = 250;
            bitrate = 128;
            useAudioFromVideo = true;
            useExistingAudio = false;
            normalize = false;
        }
    }


    [Serializable]
    public class Snapshots
    {
        private bool enabled;
        private ImageSize size;
        private ImageCrop crop; // Pixels, must be a multiple of 2

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public ImageSize Size
        {
            get => size;
            set => size = value;
        }

        public ImageCrop Crop
        {
            get => crop;
            set => crop = value;
        }

        public Snapshots()
        {
            enabled = true;
            size = new ImageSize((int) (720 / 3), (int) (480 / 3));
            crop = new ImageCrop(0, 0, 0, 0);
        }
    }


    [Serializable]
    public class VobSubColors
    {
        private bool enabled;
        private Color[] colors;
        private bool[] transparencyEnabled;

        public bool Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public Color[] Colors
        {
            get => colors;
            set => colors = value;
        }

        public bool[] TransparencyEnabled
        {
            get => transparencyEnabled;
            set => transparencyEnabled = value;
        }

        public VobSubColors()
        {
            enabled = false;

            colors = new Color[4];
            colors[0] = Color.FromArgb(253, 253, 253); // Background
            colors[1] = Color.FromArgb(189, 189, 189); // Text
            colors[2] = Color.FromArgb(126, 126, 126); // Outline
            colors[3] = Color.FromArgb(29, 29, 29); // Anti-alias

            transparencyEnabled = new bool[4];
            transparencyEnabled[0] = true; // Background
            transparencyEnabled[1] = false; // Text
            transparencyEnabled[2] = false; // Outline
            transparencyEnabled[3] = false; // Anti-alias
        }
    }

    [Serializable]
    public class LangaugeSpecific
    {
        // Japanese
        private bool kanjiLinesOnly;

        public bool KanjiLinesOnly
        {
            get => kanjiLinesOnly;
            set => kanjiLinesOnly = value;
        }

        public LangaugeSpecific()
        {
            kanjiLinesOnly = false;
        }
    }


    [Serializable]
    public sealed class Settings // : ISerializable 
    {
        private SubSettings[] subs;
        private VideoClips videoClips;
        private AudioClips audioClips;
        private Snapshots snapshots;
        private VobSubColors vobSubColors;
        private LangaugeSpecific langaugeSpecific;

        private string outputDir;

        private bool timeShiftEnabled;

        private bool spanEnabled;
        private DateTime spanStart;
        private DateTime spanEnd;

        private string deckName;
        private int episodeStartNumber;

        private List<string> actorList;

        private int contextLeadingCount;
        private int contextTrailingCount;

        private bool contextLeadingIncludeSnapshots;
        private bool contextLeadingIncludeAudioClips;
        private bool contextLeadingIncludeVideoClips;
        private int contextLeadingRange;

        private bool contextTrailingIncludeSnapshots;
        private bool contextTrailingIncludeAudioClips;
        private bool contextTrailingIncludeVideoClips;
        private int contextTrailingRange;

        public SubSettings[] Subs
        {
            get => subs;
            set => subs = value;
        }

        public VideoClips VideoClips
        {
            get => videoClips;
            set => videoClips = value;
        }

        public AudioClips AudioClips
        {
            get => audioClips;
            set => audioClips = value;
        }

        public Snapshots Snapshots
        {
            get => snapshots;
            set => snapshots = value;
        }

        public VobSubColors VobSubColors
        {
            get => vobSubColors;
            set => vobSubColors = value;
        }

        public LangaugeSpecific LangaugeSpecific
        {
            get => langaugeSpecific;
            set => langaugeSpecific = value;
        }

        public string OutputDir
        {
            get => outputDir;
            set => outputDir = value;
        }

        public bool TimeShiftEnabled
        {
            get => timeShiftEnabled;
            set => timeShiftEnabled = value;
        }

        public bool SpanEnabled
        {
            get => spanEnabled;
            set => spanEnabled = value;
        }

        public DateTime SpanStart
        {
            get => spanStart;
            set => spanStart = value;
        }

        public DateTime SpanEnd
        {
            get => spanEnd;
            set => spanEnd = value;
        }

        public string DeckName
        {
            get => deckName;
            set => deckName = value.Trim().Replace(" ", "_");
        }

        public int EpisodeStartNumber
        {
            get => episodeStartNumber;
            set => episodeStartNumber = value;
        }

        public List<string> ActorList
        {
            get => actorList;
            set => actorList = value;
        }

        public int ContextLeadingCount
        {
            get => contextLeadingCount;
            set => contextLeadingCount = value;
        }

        public int ContextTrailingCount
        {
            get => contextTrailingCount;
            set => contextTrailingCount = value;
        }

        public bool ContextLeadingIncludeSnapshots
        {
            get => contextLeadingIncludeSnapshots;
            set => contextLeadingIncludeSnapshots = value;
        }

        public bool ContextLeadingIncludeAudioClips
        {
            get => contextLeadingIncludeAudioClips;
            set => contextLeadingIncludeAudioClips = value;
        }

        public bool ContextLeadingIncludeVideoClips
        {
            get => contextLeadingIncludeVideoClips;
            set => contextLeadingIncludeVideoClips = value;
        }

        public int ContextLeadingRange
        {
            get => contextLeadingRange;
            set => contextLeadingRange = value;
        }

        public bool ContextTrailingIncludeSnapshots
        {
            get => contextTrailingIncludeSnapshots;
            set => contextTrailingIncludeSnapshots = value;
        }

        public bool ContextTrailingIncludeAudioClips
        {
            get => contextTrailingIncludeAudioClips;
            set => contextTrailingIncludeAudioClips = value;
        }

        public bool ContextTrailingIncludeVideoClips
        {
            get => contextTrailingIncludeVideoClips;
            set => contextTrailingIncludeVideoClips = value;
        }

        public int ContextTrailingRange
        {
            get => contextTrailingRange;
            set => contextTrailingRange = value;
        }

        public static Settings Instance { get; } = new Settings();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Settings()
        {
        }

        private Settings()
        {
            reset();
        }

        //public void GetObjectData(SerializationInfo info, StreamingContext context)
        //{
        //  //info.SetType(typeof(SettingsSerializationHelper));

        //}

        public void loadSettings(SaveSettings settings)
        {
            subs = settings.subs;
            subs[0].Files = new string[0];
            subs[1].Files = new string[0];
            videoClips = settings.videoClips;
            videoClips.Files = new string[0];
            audioClips = settings.audioClips;
            audioClips.Files = new string[0];
            snapshots = settings.snapshots;
            vobSubColors = settings.vobSubColors;
            langaugeSpecific = settings.langaugeSpecific;

            outputDir = settings.outputDir;

            timeShiftEnabled = settings.timeShiftEnabled;

            spanEnabled = settings.spanEnabled;
            spanStart = settings.spanStart;
            spanEnd = settings.spanEnd;

            deckName = settings.deckName;
            episodeStartNumber = settings.episodeStartNumber;

            actorList = settings.actorList;

            contextLeadingCount = settings.contextLeadingCount;
            contextLeadingIncludeSnapshots = settings.contextLeadingIncludeSnapshots;
            contextLeadingIncludeAudioClips = settings.contextLeadingIncludeAudioClips;
            contextLeadingIncludeVideoClips = settings.contextLeadingIncludeVideoClips;
            contextLeadingRange = settings.contextLeadingRange;

            contextTrailingCount = settings.contextTrailingCount;
            contextTrailingIncludeSnapshots = settings.contextTrailingIncludeSnapshots;
            contextTrailingIncludeAudioClips = settings.contextTrailingIncludeAudioClips;
            contextTrailingIncludeVideoClips = settings.contextTrailingIncludeVideoClips;
            contextTrailingRange = settings.contextTrailingRange;
        }

        public void reset()
        {
            loadSettings(new SaveSettings());
        }
    }


    [Serializable]
    internal class SettingsSerializationHelper : IObjectReference
    {
        public object GetRealObject(StreamingContext context)
        {
            return Settings.Instance;
        }
    }


    [Serializable]
    public class SaveSettings
    {
        public SubSettings[] subs;
        public VideoClips videoClips;
        public AudioClips audioClips;
        public Snapshots snapshots;
        public VobSubColors vobSubColors;
        public LangaugeSpecific langaugeSpecific;

        public string outputDir;

        public bool timeShiftEnabled;

        public bool spanEnabled;
        public DateTime spanStart;
        public DateTime spanEnd;

        public string deckName;
        public int episodeStartNumber;

        public List<string> actorList;

        public int contextLeadingCount;
        public bool contextLeadingIncludeSnapshots;
        public bool contextLeadingIncludeAudioClips;
        public bool contextLeadingIncludeVideoClips;
        public int contextLeadingRange;

        public int contextTrailingCount;
        public bool contextTrailingIncludeSnapshots;
        public bool contextTrailingIncludeAudioClips;
        public bool contextTrailingIncludeVideoClips;
        public int contextTrailingRange;

        public SaveSettings()
        {
            subs = new SubSettings[2];
            subs[0] = new SubSettings();
            subs[1] = new SubSettings();
            subs[0].ActorsEnabled = true;
            subs[0].TimingsEnabled = true;

            videoClips = new VideoClips();
            audioClips = new AudioClips();
            snapshots = new Snapshots();
            vobSubColors = new VobSubColors();
            langaugeSpecific = new LangaugeSpecific();
            outputDir = "";
            timeShiftEnabled = false;
            spanEnabled = false;
            spanStart = new DateTime();
            spanStart = spanEnd.AddMilliseconds(60 * 1.5 * 1000);
            spanEnd = new DateTime();
            spanEnd = spanEnd.AddMilliseconds(60 * 22.5 * 1000);
            deckName = "";
            episodeStartNumber = 1;

            actorList = new List<string>();

            contextLeadingCount = 0;
            contextLeadingIncludeSnapshots = false;
            contextLeadingIncludeAudioClips = false;
            contextLeadingIncludeVideoClips = false;
            contextLeadingRange = 15;

            contextTrailingCount = 0;
            contextTrailingIncludeSnapshots = false;
            contextTrailingIncludeAudioClips = false;
            contextTrailingIncludeVideoClips = false;
            contextTrailingRange = 15;
        }

        public void gatherData()
        {
            subs = Settings.Instance.Subs;
            videoClips = Settings.Instance.VideoClips;
            audioClips = Settings.Instance.AudioClips;
            snapshots = Settings.Instance.Snapshots;
            vobSubColors = Settings.Instance.VobSubColors;
            langaugeSpecific = Settings.Instance.LangaugeSpecific;

            outputDir = Settings.Instance.OutputDir;

            timeShiftEnabled = Settings.Instance.TimeShiftEnabled;

            spanEnabled = Settings.Instance.SpanEnabled;
            spanStart = Settings.Instance.SpanStart;
            spanEnd = Settings.Instance.SpanEnd;

            deckName = Settings.Instance.DeckName;
            episodeStartNumber = Settings.Instance.EpisodeStartNumber;

            actorList = Settings.Instance.ActorList;

            contextLeadingCount = Settings.Instance.ContextLeadingCount;
            contextLeadingIncludeSnapshots = Settings.Instance.ContextLeadingIncludeAudioClips;
            contextLeadingIncludeAudioClips = Settings.Instance.ContextLeadingIncludeAudioClips;
            contextLeadingIncludeVideoClips = Settings.Instance.ContextLeadingIncludeVideoClips;
            contextLeadingRange = Settings.Instance.ContextLeadingRange;

            contextTrailingCount = Settings.Instance.ContextTrailingCount;
            contextTrailingIncludeSnapshots = Settings.Instance.ContextTrailingIncludeSnapshots;
            contextTrailingIncludeAudioClips = Settings.Instance.ContextTrailingIncludeAudioClips;
            contextTrailingIncludeVideoClips = Settings.Instance.ContextTrailingIncludeVideoClips;
            contextTrailingRange = Settings.Instance.ContextTrailingRange;
        }
    }
}