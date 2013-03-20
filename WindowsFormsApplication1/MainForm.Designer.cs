namespace LdrDat2Obj
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.exitButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            this.sourceTextBox = new System.Windows.Forms.TextBox();
            this.findPartsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.openTextBox = new System.Windows.Forms.TextBox();
            this.openButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.noBottomCheckBox = new System.Windows.Forms.CheckBox();
            this.noHollowCheckBox = new System.Windows.Forms.CheckBox();
            this.noStudsCheckBox = new System.Windows.Forms.CheckBox();
            this.fileErrorCheckBox = new System.Windows.Forms.CheckBox();
            this.lineCheckBox = new System.Windows.Forms.CheckBox();
            this.stepCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel5.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 264);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.exitButton);
            this.flowLayoutPanel1.Controls.Add(this.helpButton);
            this.flowLayoutPanel1.Controls.Add(this.startButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 226);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(648, 35);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(570, 3);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(489, 3);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(408, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel5, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(648, 217);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel5
            // 
            this.flowLayoutPanel5.Controls.Add(this.sourceTextBox);
            this.flowLayoutPanel5.Controls.Add(this.findPartsButton);
            this.flowLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel5.Location = new System.Drawing.Point(3, 175);
            this.flowLayoutPanel5.Name = "flowLayoutPanel5";
            this.flowLayoutPanel5.Size = new System.Drawing.Size(642, 39);
            this.flowLayoutPanel5.TabIndex = 0;
            // 
            // sourceTextBox
            // 
            this.sourceTextBox.Location = new System.Drawing.Point(3, 3);
            this.sourceTextBox.Name = "sourceTextBox";
            this.sourceTextBox.Size = new System.Drawing.Size(541, 20);
            this.sourceTextBox.TabIndex = 2;
            // 
            // findPartsButton
            // 
            this.findPartsButton.Location = new System.Drawing.Point(550, 3);
            this.findPartsButton.Name = "findPartsButton";
            this.findPartsButton.Size = new System.Drawing.Size(75, 23);
            this.findPartsButton.TabIndex = 3;
            this.findPartsButton.Text = "Find Parts...";
            this.findPartsButton.UseVisualStyleBackColor = true;
            this.findPartsButton.Click += new System.EventHandler(this.findPartsButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.openTextBox);
            this.flowLayoutPanel2.Controls.Add(this.openButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 130);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(642, 39);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // openTextBox
            // 
            this.openTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openTextBox.Location = new System.Drawing.Point(3, 3);
            this.openTextBox.Name = "openTextBox";
            this.openTextBox.Size = new System.Drawing.Size(541, 20);
            this.openTextBox.TabIndex = 0;
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(550, 3);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open...";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel3.Controls.Add(this.noBottomCheckBox, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.noHollowCheckBox, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.noStudsCheckBox, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.fileErrorCheckBox, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lineCheckBox, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.stepCheckBox, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(642, 121);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // noBottomCheckBox
            // 
            this.noBottomCheckBox.AutoSize = true;
            this.noBottomCheckBox.Location = new System.Drawing.Point(219, 93);
            this.noBottomCheckBox.Name = "noBottomCheckBox";
            this.noBottomCheckBox.Size = new System.Drawing.Size(130, 17);
            this.noBottomCheckBox.TabIndex = 4;
            this.noBottomCheckBox.Text = "Remove bottom tubes";
            this.noBottomCheckBox.UseVisualStyleBackColor = true;
            // 
            // noHollowCheckBox
            // 
            this.noHollowCheckBox.AutoSize = true;
            this.noHollowCheckBox.Location = new System.Drawing.Point(219, 64);
            this.noHollowCheckBox.Name = "noHollowCheckBox";
            this.noHollowCheckBox.Size = new System.Drawing.Size(127, 17);
            this.noHollowCheckBox.TabIndex = 3;
            this.noHollowCheckBox.Text = "Remove hollow studs";
            this.noHollowCheckBox.UseVisualStyleBackColor = true;
            // 
            // noStudsCheckBox
            // 
            this.noStudsCheckBox.AutoSize = true;
            this.noStudsCheckBox.Location = new System.Drawing.Point(219, 35);
            this.noStudsCheckBox.Name = "noStudsCheckBox";
            this.noStudsCheckBox.Size = new System.Drawing.Size(94, 17);
            this.noStudsCheckBox.TabIndex = 2;
            this.noStudsCheckBox.Text = "Remove studs";
            this.noStudsCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileErrorCheckBox
            // 
            this.fileErrorCheckBox.AutoSize = true;
            this.fileErrorCheckBox.Location = new System.Drawing.Point(432, 35);
            this.fileErrorCheckBox.Name = "fileErrorCheckBox";
            this.fileErrorCheckBox.Size = new System.Drawing.Size(101, 17);
            this.fileErrorCheckBox.TabIndex = 5;
            this.fileErrorCheckBox.Text = "Ignore file errors";
            this.fileErrorCheckBox.UseVisualStyleBackColor = true;
            // 
            // lineCheckBox
            // 
            this.lineCheckBox.AutoSize = true;
            this.lineCheckBox.Location = new System.Drawing.Point(6, 35);
            this.lineCheckBox.Name = "lineCheckBox";
            this.lineCheckBox.Size = new System.Drawing.Size(92, 17);
            this.lineCheckBox.TabIndex = 0;
            this.lineCheckBox.Text = "Group by Line";
            this.lineCheckBox.UseVisualStyleBackColor = true;
            // 
            // stepCheckBox
            // 
            this.stepCheckBox.AutoSize = true;
            this.stepCheckBox.Location = new System.Drawing.Point(6, 64);
            this.stepCheckBox.Name = "stepCheckBox";
            this.stepCheckBox.Size = new System.Drawing.Size(94, 17);
            this.stepCheckBox.TabIndex = 1;
            this.stepCheckBox.Text = "Group by Step";
            this.stepCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Group options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(219, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Filter options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(432, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Other options";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Ldraw files (*.ldr)|*.ldr|Ldraw DAT files (*.dat)|*.dat|Ldraw MPD files (*.mpd)|*" +
                ".mpd";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "obj";
            this.saveFileDialog.Filter = "Wavefront files (*.obj)|*.obj";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 264);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LdrDat2Obj";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel5.ResumeLayout(false);
            this.flowLayoutPanel5.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        private System.Windows.Forms.TextBox sourceTextBox;
        private System.Windows.Forms.Button findPartsButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox openTextBox;
        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.CheckBox lineCheckBox;
        private System.Windows.Forms.CheckBox stepCheckBox;
        private System.Windows.Forms.CheckBox noStudsCheckBox;
        private System.Windows.Forms.CheckBox noHollowCheckBox;
        private System.Windows.Forms.CheckBox noBottomCheckBox;
        private System.Windows.Forms.CheckBox fileErrorCheckBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button helpButton;
    }
}

