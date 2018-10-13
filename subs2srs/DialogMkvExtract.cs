using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace subs2srs
{
    public partial class DialogMkvExtract : Form
    {
        private List<string> selectedMkvFiles = new List<string>();
        private string outDir = "";
        private int invalidCount = 0;
        private string trackTypeToExtract = "";

        public DialogMkvExtract()
        {
            InitializeComponent();

            comboBoxTrackTypeToExtract.SelectedIndex = 0;
            textBoxNumFilesSelected.Text = "";
            textBoxOutDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }


        private void DialogMkvExtract_FormClosing(object sender, FormClosingEventArgs e)
        {
            backgroundWorkerMain.CancelAsync();
        }

        private string convertFilelistToStr(List<string> fileList)
        {
            string outStr = "";

            foreach (string file in fileList)
            {
                outStr += $"\"{Path.GetFileName(file)}\", ";
            }

            outStr = outStr.Trim(new char[] {',', ' '});

            return outStr;
        }


        private void updateFilelistDisplay(List<string> fileList)
        {
            textBoxMkvFiles.Text = convertFilelistToStr(fileList);

            if (fileList.Count == 1)
            {
                textBoxNumFilesSelected.Text = $"{fileList.Count.ToString()} file selected";
            }
            else
            {
                textBoxNumFilesSelected.Text = $"{fileList.Count.ToString()} files selected";
            }
        }


        private void buttonMkvFiles_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialogMkv.ShowDialog();

            if (result == DialogResult.OK)
            {
                selectedMkvFiles.Clear();

                foreach (string file in openFileDialogMkv.FileNames)
                {
                    if (Path.GetExtension(file) == ".mkv")
                    {
                        selectedMkvFiles.Add(file);
                    }
                }

                updateFilelistDisplay(selectedMkvFiles);
            }
        }


        private void buttonOutDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialogOut.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBoxOutDir.Text = folderBrowserDialogOut.SelectedPath;
            }
        }


        private void resetGuiToStartingState()
        {
            buttonExtract.Text = "&Extract";
            labelProgress.Visible = false;
            progressBarEpisode.Visible = false;
            progressBarTrack.Visible = false;
        }


        private void buttonExtract_Click(object sender, EventArgs e)
        {
            if (buttonExtract.Text == "&Extract")
            {
                errorProviderMain.Clear();

                if (validateForm())
                {
                    buttonExtract.Text = "&Stop";
                    labelProgress.Text = "";
                    labelProgress.Visible = true;
                    progressBarEpisode.Value = 0;
                    progressBarEpisode.Visible = true;
                    progressBarTrack.Value = 0;
                    progressBarTrack.Visible = true;

                    trackTypeToExtract = comboBoxTrackTypeToExtract.Text;
                    outDir = textBoxOutDir.Text;


                    backgroundWorkerMain.RunWorkerAsync();
                }
            }
            else // "Stop" was clicked
            {
                backgroundWorkerMain.CancelAsync();
            }
        }


        /// <summary>
        /// Validate GUI. Inform user if they entered invalid data.
        /// </summary>
        private bool validateForm()
        {
            bool status = false;
            invalidCount = 0;

            ValidateChildren();

            if (invalidCount == 0)
            {
                status = true;
            }
            else if (invalidCount == 1)
            {
                UtilsMsg.showErrMsg("Please correct the error on this form."
                                    + "\r\n\r\nHover the mouse over the red error bubble"
                                    + "\r\nto determine the nature of the error.");
            }
            else
            {
                UtilsMsg.showErrMsg($"Please correct the {invalidCount} errors on this form."
                                    + "\r\n\r\nHover the mouse over the red error bubbles"
                                    + "\r\nto determine the nature of the errors.");
            }

            return status;
        }


        private void textBoxMkvFiles_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            if (selectedMkvFiles.Count == 0)
            {
                error = "Please enter one or more MKV files.";
                invalidCount++;
            }

            errorProviderMain.SetError((Control) sender, error);
        }


        private void textBoxOutDir_Validating(object sender, CancelEventArgs e)
        {
            string error = null;

            if (!Directory.Exists(textBoxOutDir.Text))
            {
                error = "Please enter a valid output directory.";
                invalidCount++;
            }

            errorProviderMain.SetError((Control) sender, error);
        }


        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            MkvExtractProgress progress = new MkvExtractProgress();
            progress.MaxEpisode = selectedMkvFiles.Count;

            foreach (string file in selectedMkvFiles)
            {
                progress.CurEpisode++;

                List<MkvTrack> tracks = null;

                if (trackTypeToExtract == "All subtitle tracks")
                {
                    tracks = UtilsMkv.getSubtitleTrackList(file);
                }
                else if (trackTypeToExtract == "All audio tracks")
                {
                    tracks = UtilsMkv.getAudioTrackList(file);
                }
                else
                {
                    tracks = UtilsMkv.getTrackList(file);
                }

                progress.CurTrack = 0;
                progress.MaxTrack = tracks.Count;

                foreach (MkvTrack track in tracks)
                {
                    if (worker.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }

                    progress.CurTrack++;

                    worker.ReportProgress(0, progress);

                    string displayLang = UtilsLang.LangThreeLetter2Full(track.Lang);

                    if (displayLang == "")
                    {
                        displayLang = "Unknown";
                    }

                    string fileName =
                        $"{outDir}{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(file)} - Track {Convert.ToInt32(track.TrackID):00} - {displayLang}.{track.Extension}";

                    UtilsMkv.extractTrack(file, track.TrackID, fileName);
                }
            }
        }


        private void backgroundWorkerMain_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                MkvExtractProgress progress = (MkvExtractProgress) e.UserState;

                progressBarEpisode.Maximum = progress.MaxEpisode;
                progressBarEpisode.Value = progress.CurEpisode;

                progressBarTrack.Maximum = progress.MaxTrack;
                progressBarTrack.Value = progress.CurTrack;

                labelProgress.Text =
                    $"Extracting track {progress.CurTrack}/{progress.MaxTrack} from file {progress.CurEpisode}/{progress.MaxEpisode}...";

                Update();
            }
            catch
            {
                // Don't care
            }
        }


        private void backgroundWorkerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                // Don't care
            }
            else if (e.Error != null)
            {
                UtilsMsg.showErrMsg("Something went wrong: " + e.Error.Message);
            }
            else
            {
                UtilsMsg.showInfoMsg("Extraction complete.");
            }

            resetGuiToStartingState();
        }
    }


    public class MkvExtractProgress
    {
        public int CurEpisode { get; set; }
        public int MaxEpisode { get; set; }
        public int CurTrack { get; set; }
        public int MaxTrack { get; set; }
    }
}