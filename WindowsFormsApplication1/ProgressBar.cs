using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LdrawData;
using System.IO;

namespace LdrDat2Obj
{
    public partial class status : Form
    {

        LdrawToData work = new LdrawToData();

        public status(String sou, String inp, String outp,                     // source, input, then output
                       bool lineGroup, bool stepGroup,                         // Grouping options
                       bool noStuds, bool noHollowStuds, bool noBottomTubes,   // Skip parts options
                       bool ignoreErrors)
        {
            InitializeComponent();
            //Add listener for message...
            work.Percent += getPercent;

            this.Show();

            // Start conversion
            int x = work.Start(sou, inp, outp,
                lineGroup, stepGroup,
                noStuds, noHollowStuds, noBottomTubes,
                ignoreErrors);

            this.Close();
        }


        private void getPercent(int percent)
        {
            // Set progressbar and title with %.
            progressBar1.Value = percent;
            this.Text = percent.ToString() + "% - LdrDat2Obj - Converting...";
            Application.DoEvents();
        }

        private void stopButton_Click_1(object sender, EventArgs e)
        {
            work.Stop();
        }

        private void status_Load(object sender, EventArgs e)
        {

        }
    }
}
