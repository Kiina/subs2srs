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
using System.Windows.Forms;

namespace subs2srs
{
    /// <summary>
    /// The Subtitle Style dialog.
    /// </summary>
    public partial class DialogSubtitleStyle : Form
    {
        private InfoStyle style;

        public InfoStyle Style
        {
            get => style;
            set
            {
                style = value;
                updateGUI();
            }
        }


        public string Title
        {
            get => Text;
            set => Text = value;
        }


        private List<StyleEncoding> styleEncodings = new List<StyleEncoding>();

        public DialogSubtitleStyle()
        {
            InitializeComponent();

            comboBoxMiscEncoding.Items.AddRange(StyleEncoding.getDefaultList().ToArray());
            comboBoxMiscEncoding.SelectedIndex = 1;

            style = new InfoStyle();
            updateGUI();
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            fontDialog.FontMustExist = true;

            fontDialog.ShowDialog();

            updateFontPreview();
        }


        private void panelColor_Click(object sender, EventArgs e)
        {
            colorDialog.Color = ((Panel) sender).BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ((Panel) sender).BackColor = colorDialog.Color;
            }
        }

        private void updateFontPreview()
        {
            textBoxFont.Text = fontDialog.Font.Name + ", " + fontDialog.Font.Size + ", " + fontDialog.Font.Style;
        }

        private void updateSettings()
        {
            style.Font = fontDialog.Font;
            style.ColorPrimary = panelColorPrimary.BackColor;
            style.ColorSecondary = panelColorSecondary.BackColor;
            style.ColorOutline = panelColorOutline.BackColor;
            style.ColorShadow = panelColorShadow.BackColor;
            style.OpacityPrimary = (int) numericUpDownOpacityPrimary.Value;
            style.OpacitySecondary = (int) numericUpDownOpacitySecondary.Value;
            style.OpacityOutline = (int) numericUpDownOpacityOutline.Value;
            style.OpacityShadow = (int) numericUpDownOpacityShadow.Value;
            style.Outline = (int) numericUpDownOutline.Value;
            style.Shadow = (int) numericUpDownShadow.Value;
            style.OpaqueBox = checkBoxOpaqueBox.Checked;

            if (radioButtonAlignment1.Checked)
            {
                style.Alignment = 1;
            }
            else if (radioButtonAlignment2.Checked)
            {
                style.Alignment = 2;
            }
            else if (radioButtonAlignment3.Checked)
            {
                style.Alignment = 3;
            }
            else if (radioButtonAlignment4.Checked)
            {
                style.Alignment = 4;
            }
            else if (radioButtonAlignment5.Checked)
            {
                style.Alignment = 5;
            }
            else if (radioButtonAlignment6.Checked)
            {
                style.Alignment = 6;
            }
            else if (radioButtonAlignment7.Checked)
            {
                style.Alignment = 7;
            }
            else if (radioButtonAlignment8.Checked)
            {
                style.Alignment = 8;
            }
            else if (radioButtonAlignment9.Checked)
            {
                style.Alignment = 9;
            }

            style.MarginLeft = (int) numericUpDownMarginsLeft.Value;
            style.MarginRight = (int) numericUpDownMarginsRight.Value;
            style.MarginVertical = (int) numericUpDownMarginsVertical.Value;
            style.ScaleX = (int) numericUpDownMiscScaleX.Value;
            style.ScaleY = (int) numericUpDownMiscScaleY.Value;
            style.Rotation = (int) numericUpDownMiscRotation.Value;
            style.Spacing = (int) numericUpDownMiscSpacing.Value;
            style.Encoding = StyleEncoding.getDefaultList()[comboBoxMiscEncoding.SelectedIndex];
        }


        private void updateGUI()
        {
            fontDialog.Font = style.Font;
            panelColorPrimary.BackColor = style.ColorPrimary;
            panelColorSecondary.BackColor = style.ColorSecondary;
            panelColorOutline.BackColor = style.ColorOutline;
            panelColorShadow.BackColor = style.ColorShadow;
            numericUpDownOpacityPrimary.Value = (decimal) style.OpacityPrimary;
            numericUpDownOpacitySecondary.Value = (decimal) style.OpacitySecondary;
            numericUpDownOpacityOutline.Value = (decimal) style.OpacityOutline;
            numericUpDownOpacityShadow.Value = (decimal) style.OpacityShadow;
            numericUpDownOutline.Value = (decimal) style.Outline;
            numericUpDownShadow.Value = (decimal) style.Shadow;
            checkBoxOpaqueBox.Checked = style.OpaqueBox;

            radioButtonAlignment1.Checked = false;
            radioButtonAlignment2.Checked = false;
            radioButtonAlignment3.Checked = false;
            radioButtonAlignment4.Checked = false;
            radioButtonAlignment5.Checked = false;
            radioButtonAlignment6.Checked = false;
            radioButtonAlignment7.Checked = false;
            radioButtonAlignment8.Checked = false;
            radioButtonAlignment9.Checked = false;

            switch (style.Alignment)
            {
                case 1:
                    radioButtonAlignment1.Checked = true;
                    break;
                case 2:
                    radioButtonAlignment2.Checked = true;
                    break;
                case 3:
                    radioButtonAlignment3.Checked = true;
                    break;
                case 4:
                    radioButtonAlignment4.Checked = true;
                    break;
                case 5:
                    radioButtonAlignment5.Checked = true;
                    break;
                case 6:
                    radioButtonAlignment6.Checked = true;
                    break;
                case 7:
                    radioButtonAlignment7.Checked = true;
                    break;
                case 8:
                    radioButtonAlignment8.Checked = true;
                    break;
                case 9:
                    radioButtonAlignment9.Checked = true;
                    break;
            }

            numericUpDownMarginsLeft.Value = (decimal) style.MarginLeft;
            numericUpDownMarginsRight.Value = (decimal) style.MarginRight;
            numericUpDownMarginsVertical.Value = (decimal) style.MarginVertical;
            numericUpDownMiscScaleX.Value = (decimal) style.ScaleX;
            numericUpDownMiscScaleY.Value = (decimal) style.ScaleY;
            numericUpDownMiscRotation.Value = (decimal) style.Rotation;
            numericUpDownMiscSpacing.Value = (decimal) style.Spacing;

            for (int i = 0; i < StyleEncoding.getDefaultList().Count; i++)
            {
                if (comboBoxMiscEncoding.Items[i].ToString() == style.Encoding.ToString())
                {
                    comboBoxMiscEncoding.SelectedIndex = i;
                    break;
                }
            }

            updateFontPreview();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            updateSettings();
        }
    }
}