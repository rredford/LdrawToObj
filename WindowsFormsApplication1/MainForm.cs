using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace LdrDat2Obj
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            //Now set saved values.
            openTextBox.Text = Properties.Settings.Default.openDir;
            sourceTextBox.Text = Properties.Settings.Default.sourceDir;
            lineCheckBox.Checked = Properties.Settings.Default.lineGroup;
            stepCheckBox.Checked = Properties.Settings.Default.stepGroup;
            noStudsCheckBox.Checked = Properties.Settings.Default.noStuds;
            noHollowCheckBox.Checked = Properties.Settings.Default.noHollows;
            noBottomCheckBox.Checked = Properties.Settings.Default.noBottom;
            fileErrorCheckBox.Checked = Properties.Settings.Default.fileErrors;
        }

        private void startButton_Click(object sender, EventArgs e)
        {            
            // If save file dialog result is okay, start process
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Store filename string
                String saveFile = this.saveFileDialog.FileName;
                //Save settings
                saveSettings();

                this.Hide();

                // Create progress window. it will auto-convert file.
                status s = new status(
                    sourceTextBox.Text,
                    openTextBox.Text, saveFile,
                    lineCheckBox.Checked, stepCheckBox.Checked,
                    noStudsCheckBox.Checked, noHollowCheckBox.Checked, noBottomCheckBox.Checked,
                    fileErrorCheckBox.Checked);

                this.Show();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Save settings
            saveSettings();
            System.Windows.Forms.Application.Exit();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            // Set file to be opened if "OK"
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.openTextBox.Text = this.openFileDialog.FileName;
            }

        }

        private void findPartsButton_Click(object sender, EventArgs e)
        {
            // Set source dir if "OK"
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.sourceTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void saveSettings()
        {
            //Save settings
            Properties.Settings.Default.sourceDir = sourceTextBox.Text;
            Properties.Settings.Default.openDir = openTextBox.Text;
            Properties.Settings.Default.lineGroup = lineCheckBox.Checked;
            Properties.Settings.Default.stepGroup = stepCheckBox.Checked;
            Properties.Settings.Default.noStuds = noStudsCheckBox.Checked;
            Properties.Settings.Default.noHollows = noHollowCheckBox.Checked;
            Properties.Settings.Default.noBottom = noBottomCheckBox.Checked;
            Properties.Settings.Default.fileErrors = fileErrorCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "LdrDat2Obj 2.0 by Rolf Redford\n\n" +
"Basic usage:\n\n" +
"The only requirement for ldrdat2obj to successfully convert a model file from Ldraw to obj format is an input file and source directory for Ldraw part files. Those can be set by clicking \"Open…\" and \"Find Parts…\" buttons.\n\n" +
"Optional features:\n\n" +
"Grouping can be set by Line, which means if you had 3 bricks in a model file, those will be in separate groups. Steps means if you had 6 bricks, and 2 steps, whatever bricks you added in each step will be in its own group.\n\n" +
"You can also filter 3 types of specific subparts in order to lower polygon count. Studs is obvious, it will remove standard studs and electric connector studs. Hollow stud is typical stud with hole in it. Bottom tubes remove all rods and tubes in bottom of bricks.\n\n" +
"Ignore file errors can be helpful if you are missing some subparts or have kind of corrupted model file. It will skip invalid polygons, and hopefully model can be useful anyway.\n\n", "LdrDat2Obj Help");

        }
    }
}
