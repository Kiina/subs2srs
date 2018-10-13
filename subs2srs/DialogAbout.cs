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
using System.Windows.Forms;

namespace subs2srs
{
    /// <summary>
    /// The about dialog.
    /// </summary>
    partial class DialogAbout : Form
    {
        public DialogAbout()
        {
            InitializeComponent();
            Text = $"About {UtilsAssembly.Title}";
            labelProjectName.Text = UtilsAssembly.Product;
            labelVersion.Text = UtilsAssembly.Version;
            labelAuthor.Text = UtilsAssembly.Author;
            linkLabelWebsite.Text = $"http://sourceforge.net/projects/{UtilsAssembly.Title}/";
        }

        private void linkLabelContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("Mailto:cb4960@gmail.com");
        }

        private void linkLabelWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start($"http://sourceforge.net/projects/{UtilsAssembly.Title}/");
        }
    }
}