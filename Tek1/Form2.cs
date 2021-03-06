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

    public partial class PlayForm : Form
    {
        TekView View;
        bool _lastShowErrors = false;
        public PlayForm()
        {
            InitializeComponent();
            View = new TekView(split.Panel1, new Point(10,10),
                new Point(split.Panel1.ClientRectangle.Width - 10,
                          split.Panel1.ClientRectangle.Height - 10));
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                View.LoadFromFile(ofd1.FileName);
                this.Text = ofd1.FileName;
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

        private void bUnPlay_Click(object sender, EventArgs e)
        {
            View.UnPlay();

        }

        private void bTakeSnap_Click(object sender, EventArgs e)
        {
            View.TakeSnapshot(String.Format("snapshot {0}", 1 + View.SnapshotCount()));
        }

        private void bRestoreSnap_Click(object sender, EventArgs e)
        {
            View.RestoreSnapshot("snapshot 1");
        }

        private void panel1_Resize(object sender, EventArgs e)
        {
            if (View != null)
            {
                View.SetSize(split.Panel1.Width, split.Panel1.Height);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
        }

        private void cbShowError_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            _lastShowErrors = View.SetShowErrors(!_lastShowErrors);
        }

        private void bDefaultNotes_Click(object sender, EventArgs e)
        {
            View.ShowDefaultNotes();
        }

        private void cbMultipleSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMultipleSelect.Checked)
                View.Selector.CurrentMode = TekSelect.SelectMode.smMultiple;
            else
                View.Selector.CurrentMode = TekSelect.SelectMode.smSingle;
        }
    }

   
    
}
