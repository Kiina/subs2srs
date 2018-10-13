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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace subs2srs
{
    /// <summary>
    /// A generic progress dialog.
    /// </summary>
    public partial class DialogProgress : Form
    {
        private int stepsCurrent;
        private bool detailedProgress;

        public bool Cancel { get; private set; } = false;

        public int StepsCurrent
        {
            get => stepsCurrent;
            set
            {
                stepsCurrent = value;
                updateTitles();
            }
        }

        public int StepsTotal { get; set; }

        public string StepName { get; set; }

        public bool DetailedProgress
        {
            get => detailedProgress;
            set
            {
                detailedProgress = value;

                if (detailedProgress)
                {
                    progressBarDetailed.Visible = true;
                    ClientSize = new Size(ClientSize.Width, 145);
                }
                else
                {
                    labelStatsTimeProcessed.Visible = false;
                    labelStatsTimeProcessedValue.Visible = false;
                    labelStatsTimeRemaining.Visible = false;
                    labelStatsTimeRemainingValue.Visible = false;
                    labelStatsFps.Visible = false;
                    labelStatsFpsValue.Visible = false;
                    labelStatsFrame.Visible = false;
                    labelStatsFrameValue.Visible = false;

                    progressBarDetailed.Visible = false;
                    ClientSize = new Size(ClientSize.Width, 110);
                }
            }
        }

        public DateTime Duration { get; set; }

        public DataReceivedEventHandler FFmpegOutputHandler => ffmpegOutputHandler;


        public DialogProgress()
        {
            InitializeComponent();
            stepsCurrent = 0;
            StepsTotal = 0;
            StepName = "";
            DetailedProgress = false;
            updateTitles();
            Duration = new DateTime();
        }

        private void updateTitles()
        {
            string title = "Progress";

            if (stepsCurrent > 0 && StepsTotal > 0)
            {
                title += $" - Step {stepsCurrent} of {StepsTotal}";

                if (StepName.Length > 0)
                {
                    title += $" - {StepName}";
                }
            }

            Text = title;
        }

        public void updateProgress(int progress, string text)
        {
            labelDesc.Text = text;

            if (progress < 0)
            {
                progressBarMain.Style = ProgressBarStyle.Marquee;
            }
            else
            {
                progressBarMain.Style = ProgressBarStyle.Blocks;
                progressBarMain.Value = Math.Min(100, progress);
            }
        }

        public void updateProgress(string text)
        {
            labelDesc.Text = text;
        }

        public void updateDetailedProgress(int progress, InfoFFmpegProgress ffmpegProgress)
        {
            progressBarDetailed.Value = Math.Min(100, progress);
            progressBarDetailed.Style = ProgressBarStyle.Marquee;

            if (progress > 0)
            {
                progressBarDetailed.Style = ProgressBarStyle.Blocks;
                DateTime timeRemaining = UtilsSubs.getDurationTime(ffmpegProgress.Time, Duration);

                labelStatsTimeProcessed.Visible = true;
                labelStatsTimeProcessedValue.Visible = true;
                labelStatsTimeRemaining.Visible = true;
                labelStatsTimeRemainingValue.Visible = true;

                if (ffmpegProgress.VideoProgress)
                {
                    labelStatsFps.Visible = true;
                    labelStatsFpsValue.Visible = true;
                    labelStatsFrame.Visible = true;
                    labelStatsFrameValue.Visible = true;
                }
                else
                {
                    labelStatsFps.Visible = false;
                    labelStatsFpsValue.Visible = false;
                    labelStatsFrame.Visible = false;
                    labelStatsFrameValue.Visible = false;
                }

                labelStatsTimeProcessedValue.Text =
                    $"{ffmpegProgress.Time.TimeOfDay.Hours:00}:{ffmpegProgress.Time.TimeOfDay.Minutes:00}:{ffmpegProgress.Time.TimeOfDay.Seconds:00}";


                labelStatsTimeRemainingValue.Text =
                    $"{timeRemaining.TimeOfDay.Hours:00}:{timeRemaining.TimeOfDay.Minutes:00}:{timeRemaining.TimeOfDay.Seconds:00}";

                if (ffmpegProgress.VideoProgress)
                {
                    labelStatsFpsValue.Text = $"{ffmpegProgress.FPS}";
                    labelStatsFrameValue.Text = $"{ffmpegProgress.Frame}";
                }
            }
        }

        private void FormProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cancel = true;
            e.Cancel = true;
        }


        public static void updateProgressInvoke(DialogProgress dialogProgress, int progress, string text)
        {
            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate() { dialogProgress.updateProgress(progress, text); });
            }
        }


        public static void updateProgressInvoke(DialogProgress dialogProgress, string text)
        {
            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate() { dialogProgress.updateProgress(text); });
            }
        }


        public static void updateDetailedProgressInvoke(DialogProgress dialogProgress, int progress,
            InfoFFmpegProgress ffmpegProgress)
        {
            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate()
                {
                    dialogProgress.updateDetailedProgress(progress, ffmpegProgress);
                });
            }
        }


        public static void nextStepInvoke(DialogProgress dialogProgress, int step, string stepName)
        {
            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate()
                {
                    dialogProgress.StepName = stepName;
                    dialogProgress.StepsCurrent = step;
                });
            }
        }


        public static void enableDetailInvoke(DialogProgress dialogProgress, bool enabled)
        {
            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate() { dialogProgress.DetailedProgress = enabled; });
            }
        }


        public static bool getCancelInvoke(DialogProgress dialogProgress)
        {
            bool cancelState = false;

            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate() { cancelState = dialogProgress.Cancel; });
            }

            return cancelState;
        }

        public static void setDuration(DialogProgress dialogProgress, DateTime duration)
        {
            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate() { dialogProgress.Duration = duration; });
            }
        }

        public static DataReceivedEventHandler getFFmpegOutputHandler(DialogProgress dialogProgress)
        {
            DataReceivedEventHandler outHandler = null;

            // Wait for thread to become avaiable
            if (dialogProgress.IsHandleCreated)
            {
                dialogProgress.Invoke((MethodInvoker) delegate() { outHandler = dialogProgress.FFmpegOutputHandler; });
            }

            return outHandler;
        }

        public void ffmpegOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                InfoFFmpegProgress ffmpegProgress = new InfoFFmpegProgress();

                bool parseSuccess = ffmpegProgress.parseFFmpegProgress(outLine.Data);

                if (parseSuccess)
                {
                    int progress = (int) (ffmpegProgress.Time.TimeOfDay.TotalMilliseconds /
                                          Math.Max(1, Duration.TimeOfDay.TotalMilliseconds) * 100);

                    updateDetailedProgressInvoke(this, progress, ffmpegProgress);

                    // Debug
                    //TextWriter writer = new StreamWriter("ffmpeg_output.txt", true, Encoding.UTF8);
                    //writer.WriteLine(outLine.Data);
                    //writer.WriteLine(String.Format("Progress: {0:00}", progress));
                    //writer.Close();
                }
            }
        }
    }
}