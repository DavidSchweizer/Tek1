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
        TekBoardPanel P;

        public Form2()
        {
            InitializeComponent();
            P = new TekBoardPanel();
            panel1.Controls.Add(P);
            P.Top = 10;
            P.Left = 10;
            P.Width = panel1.ClientRectangle.Width - 20;
            P.Height = panel1.ClientRectangle.Height - 20;
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                TekBoardParser tbp = new TekBoardParser();
                TekBoard board = null;
                try
                {
                    board = tbp.Import(ofd1.FileName);
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
                if (board != null)
                {
                    this.P.Board = board;
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int value = 0;
            if (TekFieldPanel.SelectedPanel != null && (sender is Button) && Int32.TryParse((sender as Button).Text, out value))
            {
                if (TekFieldPanel.SelectedPanel.Value == value)
                    TekFieldPanel.SelectedPanel.Value = 0;
                else
                    TekFieldPanel.SelectedPanel.Value = value;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            sfd1.FileName = ofd1.FileName;
            sfd1.InitialDirectory = ofd1.InitialDirectory;
            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                TekBoardParser tbp = new TekBoardParser();
                tbp.Export(P.Board, sfd1.FileName);
            }
        }
        private void Panel_KeyDown(object sender, KeyEventArgs e)
        {
            if (TekFieldPanel.SelectedPanel != null)
            {
                switch(e.KeyCode)
                {
                    case Keys.D1:
                        TekFieldPanel.SelectedPanel.Value = 1;
                        break;
                }
            }
        }

        private void bSolveClick(object sender, EventArgs e)
        {
            if (P.Board != null)
            {
                P.Board.Dump("dumping.dmp");
                TekSolver solver = new TekSolver(P.Board);
                if (!solver.Solve())
                    MessageBox.Show("can not be solved");
                Refresh();
                using (StreamWriter sw = new StreamWriter("solver.dmp"))
                {
                    solver.Dump(sw);
                }
            }

        }

        private void bReset_Click(object sender, EventArgs e)
        {
            P.Board.ResetValues();
            Refresh();
        }
    }

    class TekPanelData
    {
        const int MAXTILESIZE = 60;
        FontFamily fontFamily = new FontFamily("Arial");
        int FontSize;
        public Font[] ValueFont;
        public SolidBrush[] solidBrush;
        public Point ValuePoint;
        private StringFormat format = new StringFormat();
        public StringFormat Format { get { return format; } }

        private int _tileSize;
        public int TileSize { get { return _tileSize; } set { SetTileSize(value); } }
        public void SetTileSize(int value)
        {
            
            if (value > MAXTILESIZE)
                _tileSize = MAXTILESIZE;
            else
                _tileSize = value;
            FontSize = Convert.ToInt32(TileSize * 0.7);
            ValueFont = new Font[2];
            ValueFont[0] = 
                new Font(fontFamily, FontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            ValueFont[1] =
                new Font(fontFamily, FontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            solidBrush = new SolidBrush[2];
            solidBrush[0] = new SolidBrush(Color.Black);
            solidBrush[1] = new SolidBrush(Color.White);
            ValuePoint = new Point(TileSize / 2, TileSize / 2);
        }

        public void SetCenterAlignment()
        {
            Format.LineAlignment = StringAlignment.Center;
            Format.Alignment = StringAlignment.Center;
        }
    }

    class TekBoardPanel : Panel
    {
        static System.Drawing.Color[] AreaColors =
            { Color.LightGreen, Color.Orange, Color.LightSkyBlue,
              Color.LightPink, Color.LightYellow, Color.LightSalmon,
              Color.LightGray, Color.Beige, Color.DeepPink
            };
        static System.Drawing.Color[] SelectedAreaColors =
             { Color.Chartreuse, Color.DarkOrange, Color.DeepSkyBlue,
              Color.HotPink, Color.Goldenrod, Color.Salmon,
              Color.SlateGray, Color.SaddleBrown, Color.Fuchsia
            };
        const int MAXCOLOR = 9;
        static int[] AreaColorIndex = null;

        private TekFieldPanel[,] _Panels = null;

        private TekPanelData data = new TekPanelData();

        private TekBoard board = null;
        public TekBoard Board { get { return board; } set { SetBoard(value); } }

        private void SetBoard(TekBoard value)
        {
            board = value;
            BackColor = System.Drawing.Color.CadetBlue;
            SetAreaColors(board);
            initializePanels();
            SetBorders();
        }

        private void removeBoard()
        {
            if (_Panels == null)
                return;
            for (int r = 0; r < _Panels.GetLength(0); r++)
                for (int c = 0; c < _Panels.GetLength(1); c++)
                {
                    this.Controls.Remove(_Panels[r, c]);
                    _Panels[r, c] = null;
                }
            _Panels = null;
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            if (Board == null)
                return;
            if (sender is TekFieldPanel)
            {
                TekFieldPanel panel = sender as TekFieldPanel;
                panel.SelectPanel(!panel.IsSelected);
            }
        }

        private void initializePanels()
        {
            const int PADDING = 11;
            var clr1 = Color.DarkGray;
            var clr2 = Color.White;
            Random R = new Random();

            removeBoard();
            if (Board == null)
                return;

            data.TileSize = Math.Min((this.ClientRectangle.Width - PADDING) / Board.Cols, (this.ClientRectangle.Height - PADDING) / Board.Rows);

            _Panels = new TekFieldPanel[Board.Rows, Board.Cols];

            for (int r = 0; r < Board.Rows; r++)
                for (int c = 0; c < Board.Cols; c++)
                {
                    TekFieldPanel newP = new TekFieldPanel
                    {
                        Size = new Size(data.TileSize, data.TileSize),
                        Location = new Point(PADDING / 2 + data.TileSize * c, PADDING / 2 + data.TileSize * r)
                    };
                    newP.Data = data;
                    newP.Field = Board.values[r, c];
                    newP.NormalColor = AreaColors[AreaColorIndex[newP.Field.area.AreaNum]];
                    newP.SelectedColor = SelectedAreaColors[AreaColorIndex[newP.Field.area.AreaNum]];
                    newP.Click += new EventHandler(Panel_Click);
                    //                    newP.KeyDown+= new EventHandler(Panel_KeyDown);
                    this.Controls.Add(newP);
                    _Panels[r, c] = newP;
                }
        }

        private void SetAreaColors(TekBoard board)
        {
            AreaColorIndex = new int[board.areas.Count()];
            for (int i = 0; i < AreaColorIndex.Length; i++)
                AreaColorIndex[i] = -1; // 
            Random R = new Random();
            foreach (TekArea area in board.areas)
            {
                List<TekArea> neighbours = area.GetAdjacentAreas();
                List<int> inUseByNeighbours = new List<int>();
                foreach (TekArea area2 in neighbours)
                    if (AreaColorIndex[area2.AreaNum] != -1)
                        inUseByNeighbours.Add(AreaColorIndex[area2.AreaNum]);
                int index0 = R.Next(MAXCOLOR);
                int index = (index0 + 1) % MAXCOLOR;
                while (index != index0)
                {
                    if (inUseByNeighbours.Contains(index))
                        index = (index + 1) % MAXCOLOR;
                    else
                        break;
                }
                AreaColorIndex[area.AreaNum] = index;
            }
        }

        private void SetBorders()
        {
            if (Board == null || _Panels == null)
                return;
            int area = Board.values[0, 0].area.AreaNum;
            for (int r = 0; r < Board.Rows; r++)
                for (int c = 0; c < Board.Cols; c++)
                {
                    TekFieldPanel p = _Panels[r, c];
                    if (r == 0)
                        p.Borders[(int)TekFieldPanel.TekBorder.bdTop] = TekFieldPanel.TekBorderStyle.tbsBoard;
                    else
                    {
                        TekField f2 = Board.values[r - 1, c];
                        if (f2.area.AreaNum == p.Field.area.AreaNum)
                            p.Borders[(int)TekFieldPanel.TekBorder.bdTop] = TekFieldPanel.TekBorderStyle.tbsInternal;
                        else
                            p.Borders[(int)TekFieldPanel.TekBorder.bdTop] = TekFieldPanel.TekBorderStyle.tbsExternal;
                    }
                    if (c == 0)
                        p.Borders[(int)TekFieldPanel.TekBorder.bdLeft] = TekFieldPanel.TekBorderStyle.tbsBoard;
                    else
                    {
                        TekField f2 = Board.values[r, c - 1];
                        if (f2.area.AreaNum == p.Field.area.AreaNum)
                            p.Borders[(int)TekFieldPanel.TekBorder.bdLeft] = TekFieldPanel.TekBorderStyle.tbsInternal;
                        else
                            p.Borders[(int)TekFieldPanel.TekBorder.bdLeft] = TekFieldPanel.TekBorderStyle.tbsExternal;
                    }
                    if (r == Board.Rows - 1)
                        p.Borders[(int)TekFieldPanel.TekBorder.bdBottom] = TekFieldPanel.TekBorderStyle.tbsBoard;
                    else
                    {
                        TekField f2 = Board.values[r + 1, c];
                        if (f2.area.AreaNum == p.Field.area.AreaNum)
                            p.Borders[(int)TekFieldPanel.TekBorder.bdBottom] = TekFieldPanel.TekBorderStyle.tbsInternal;
                        else
                            p.Borders[(int)TekFieldPanel.TekBorder.bdBottom] = TekFieldPanel.TekBorderStyle.tbsExternal;
                    }
                    if (c == Board.Cols - 1)
                        p.Borders[(int)TekFieldPanel.TekBorder.bdRight] = TekFieldPanel.TekBorderStyle.tbsBoard;
                    else
                    {
                        TekField f2 = Board.values[r, c + 1];
                        if (f2.area.AreaNum == p.Field.area.AreaNum)
                            p.Borders[(int)TekFieldPanel.TekBorder.bdRight] = TekFieldPanel.TekBorderStyle.tbsInternal;
                        else
                            p.Borders[(int)TekFieldPanel.TekBorder.bdRight] = TekFieldPanel.TekBorderStyle.tbsExternal;
                    }
                }
        }
    }

    class TekFieldPanel : Panel
    {
        public enum TekBorder { bdTop, bdRight, bdBottom, bdLeft, bdLast };
        public enum TekBorderStyle { tbsNone, tbsInternal, tbsExternal, tbsBoard };

        private System.Drawing.Color _NormalColor;
        public System.Drawing.Color NormalColor
        {
            get { return _NormalColor; }
            set { _NormalColor = value; if (!IsSelected) BackColor = value; }
        }

        private System.Drawing.Color _SelectedColor;
        public System.Drawing.Color SelectedColor 
        {
            get { return _SelectedColor; }
            set { _SelectedColor = value; if (IsSelected) BackColor = value; }
        }

        private TekField field;
        static public TekFieldPanel SelectedPanel = null;
        public bool IsSelected { get; set; }
        private TekPanelData _data;
        
        public int Row { get { return field == null ? -1 : field.Row; } }
        public int Col { get { return field == null ? -1 : field.Col; } }
        public int Value { get { return field == null ? 0 : field.Value; } set { if (field != null && !field.initial) { field.Value = value; Refresh(); } } }

        public TekBorderStyle[] Borders { get; set; }
                    
        public TekPanelData Data { get { return _data; } set { _data = value; this.Refresh(); } }

        public TekFieldPanel() : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            Borders = new TekBorderStyle[(int)TekBorder.bdLast];
            for (int b = 0; b <= (int)TekBorder.bdTop; b++)
                Borders[b] = TekBorderStyle.tbsNone;
            NormalColor = Color.AliceBlue;
            SelectedColor = Color.YellowGreen;
         }

        public void SelectPanel(bool onoff=true)
        {
            if (!onoff)
            {
                this.BackColor = NormalColor;
                SelectedPanel = null;
                IsSelected = false;
            }
            else
            {
                if (SelectedPanel != null)
                    SelectedPanel.SelectPanel(false);
                SelectedPanel = this;
                IsSelected = true;
                this.BackColor = SelectedColor;
            }
            this.Refresh();            
        }
        
        private void SetField(TekField value)
        {
            field = value;
            this.Refresh();
        }

        public TekField Field
        {
            get { return field;  }
            set { SetField(value); }
        }

        private void DrawBorders(PaintEventArgs e)
        {//tbsNone, tbsInternal, tbsExternal, tbsBoard
            int[] penSizes = { 0, 1, 2, 1 };
            System.Drawing.Color[] bColors = { Color.White, Color.DarkGray, Color.Black, Color.Black };
            System.Drawing.Color SelectedBorderColor = Color.NavajoWhite;

            int[] X1 = { 0, e.ClipRectangle.Width,  e.ClipRectangle.Width, 0 };
            int[] X2 = { e.ClipRectangle.Width, e.ClipRectangle.Width, 0, 0 };
            int[] Y1 = { 0, 0, e.ClipRectangle.Height, e.ClipRectangle.Height  };
            int[] Y2 = { 0, e.ClipRectangle.Height, e.ClipRectangle.Height, 0};

            for (int i = (int)TekBorder.bdTop; i < (int)TekBorder.bdLast; i++)
            {
                int ps = penSizes[(int)Borders[i]];
                Pen pen = new Pen(
                    new SolidBrush(bColors[(int)Borders[i]]), ps
                    );
                if (ps > 1)
                {
                    ps = ps / 2;
                    if (i == (int)TekBorder.bdTop)
                    {
                        Y1[i] += ps; Y2[i] += ps;
                    }
                    if (i == (int)TekBorder.bdLeft)
                    {
                        X1[i] += ps; X2[i] += ps;
                    }
                }
//                Pen pen = new Pen(
 //                       new SolidBrush(IsSelected ? SelectedBorderColor : bColors[(int)Borders[i]]),
  //                      IsSelected ? 3 : penSizes[(int)Borders[i]]);
               //pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Left;
                
                e.Graphics.DrawLine(pen, X1[i], Y1[i], X2[i], Y2[i]);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            base.OnPaint(e);

            if (Field != null && Field.Value > 0)
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                Data.SetCenterAlignment();
                e.Graphics.DrawString(Field.Value.ToString(), Data.ValueFont[field.initial?1:0], 
                        Data.solidBrush[IsSelected?1:0], Data.ValuePoint, Data.Format);
            }
            DrawBorders(e);
        }
    }
    
}
