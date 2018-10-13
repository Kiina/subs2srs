using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace subs2srs
{
    public partial class DialogSelectMkvTrack : Form
    {
        private string mvkFile = "";
        private int subsNum = 1;
        private List<MkvTrack> subTrackList = new List<MkvTrack>();
        private MkvTrack selectedTrack = new MkvTrack();

        public string ExtractedFile { get; set; }

        public DialogSelectMkvTrack(string mvkFile, int subsNum, List<MkvTrack> subTrackList)
        {
            InitializeComponent();
            this.mvkFile = mvkFile;
            this.subsNum = subsNum;
            this.subTrackList = subTrackList;
            ExtractedFile = "";
        }

        private void DialogSelectMkvTrack_Load(object sender, EventArgs e)
        {
            labelProgress.Visible = false;
            progressBarMain.Visible = false;

            foreach (MkvTrack track in subTrackList)
            {
                comboBoxTrack.Items.Add(track);
            }

            comboBoxTrack.SelectedIndex = 0;
        }


        private void buttonExtract_Click(object sender, EventArgs e)
        {
            labelProgress.Visible = true;
            progressBarMain.Visible = true;
            buttonExtract.Enabled = false;
            selectedTrack = (MkvTrack) comboBoxTrack.SelectedItem;

            backgroundWorkerMain.RunWorkerAsync();
        }


        private void backgroundWorkerMain_DoWork(object sender, DoWorkEventArgs e)
        {
            string tempFileName = ConstantSettings.TempMkvExtractSubs1Filename;

            if (subsNum == 2)
            {
                tempFileName = ConstantSettings.TempMkvExtractSubs2Filename;
            }

            ExtractedFile = $"{Path.GetTempPath()}{tempFileName}.{selectedTrack.Extension}";

            UtilsMkv.extractTrack(mvkFile, selectedTrack.TrackID, ExtractedFile);

            // The subs1 and subs2 textboxes, take .idx files rather than .sub files
            if (Path.GetExtension(ExtractedFile) == ".sub")
            {
                ExtractedFile = Path.ChangeExtension(ExtractedFile, ".idx");
            }
        }


        private void backgroundWorkerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}