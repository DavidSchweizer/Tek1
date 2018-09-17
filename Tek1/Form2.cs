using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tek1
{

    public partial class Form2 : Form
    {
        TekView View;

        public Form2()
        {
            InitializeComponent();
            View = new TekView(panel1, new Point(10,10),
                new Point(panel1.ClientRectangle.Width - 10,
                          panel1.ClientRectangle.Height - 10));
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                View.LoadFromFile(ofd1.FileName);
            }
        }

        private void Button_ToggleValue_Click(object sender, EventArgs e)
        {
            if (View.Board == null)
                return;
            int value = 0;
            if ((sender is Button) && Int32.TryParse((sender as Button).Text, out value))
            {
                View.ToggleSelectedValue(value);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (View.Board == null)
                return;
            sfd1.FileName = ofd1.FileName;
            sfd1.InitialDirectory = ofd1.InitialDirectory;
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                View.SaveToFile(sfd1.FileName);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            View.HandleKeyDown(ref msg, keyData);

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void bSolveClick(object sender, EventArgs e)
        {
            if (View.Board != null && !View.Solve())
                MessageBox.Show("can not be solved");
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            View.ResetValues();
        }

        private void ToggleNoteButton_Click(object sender, EventArgs e)
        {
            int value = 0;
            if ((sender is Button) && Int32.TryParse((sender as Button).Text, out value))
                View.ToggleSelectedNoteValue(value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            View.UnPlay();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            View.TakeSnapshot(String.Format("snapshot {0}", 1 + View.SnapshotCount()));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            View.RestoreSnapshot("snapshot 1");
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (View != null)
            {
                View.Width = panel1.Width;
                View.Height = panel1.Height;
            }
        }
    }

   
    
}
