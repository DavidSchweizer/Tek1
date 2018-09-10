using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Tek1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TekBoardParser tbp = new TekBoardParser();
            TekBoard board = null;
            try
            {
                board = tbp.Import(textBox1.Text);
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            if (board != null)
            {
                Console.WriteLine("read: {0} rows, {1} cols", board.Rows, board.Cols);
                tbp.Export(board, "dump.txt");
                List<string> errors = board.ValidAreasErrors();
                listBox1.Items.Clear();
                if (errors.Count > 0)
                {                  
                    foreach (string s in errors)
                        listBox1.Items.Add(s);
                }
            }
            
            
        }
    }
}
