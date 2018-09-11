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
            if (P == null || P.Board == null)
                return;
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
            if (P == null || P.Board == null)
                return;
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
            if (P == null || P.Board == null)
                return;
                         
            P.Board.Dump("dumping.dmp");
            TekSolver solver = new TekSolver(P.Board);
            TekSolverNotes notes = new TekSolverNotes(P.Board);
            notes.SetDefaultNotes();
            using (StreamWriter sw = new StreamWriter("notes.dmp"))
            {
                notes.Dump(sw);
            }
            if (!solver.Solve())
                MessageBox.Show("can not be solved");
            Refresh();
            using (StreamWriter sw = new StreamWriter("solver.dmp"))
            {
                solver.Dump(sw);
            }            
        }

        private void bReset_Click(object sender, EventArgs e)
        {
            if (P == null || P.Board == null)
                return;
            P.Board.ResetValues();
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (P == null || P.Board == null)
                return;
            int value = 0;
            if (TekFieldPanel.SelectedPanel != null && 
                (sender is Button) && Int32.TryParse((sender as Button).Text, out value))
            {
                TekFieldPanel.SelectedPanel.ToggleNote(value);
            }

        }
    }

    class TekPanelData
    {
        const int MAXTILESIZE = 60;
        FontFamily fontFamily = new FontFamily("Calibri");
        int FontSize;
        int FontSize2;
        public Font[] ValueFont;
        public SolidBrush[] solidBrush;
        public Point ValuePoint;
        public Point[] NotePoint;
        private StringFormat format = new StringFormat();
        public StringFormat Format { get { return format; } }

        private int _tileSize;
        public int TileSize { get { return _tileSize; } set { SetTileSize(value); } }

        public const int FONT_NORMAL   = 0;
        public const int FONT_INITIAL  = 1;
        public const int FONT_NOTE     = 2;

        public const int PANEL_NORMAL = 0;
        public const int PANEL_SELECTED = 1;
       
        public void SetTileSize(int value)
        {            
            if (value > MAXTILESIZE)
                _tileSize = MAXTILESIZE;
            else
                _tileSize = value;
            FontSize = Convert.ToInt32(TileSize * 0.7);
            FontSize2 = Convert.ToInt32(FontSize / 2.5);
            ValueFont = new Font[3];
            ValueFont[FONT_NORMAL] = 
                new Font(fontFamily, FontSize, FontStyle.Regular, GraphicsUnit.Pixel);
            ValueFont[FONT_INITIAL] =
                new Font(fontFamily, FontSize, FontStyle.Bold, GraphicsUnit.Pixel);
            ValueFont[FONT_NOTE] =
                new Font(fontFamily, FontSize2, FontStyle.Regular, GraphicsUnit.Pixel);
            solidBrush = new SolidBrush[2];
            solidBrush[PANEL_NORMAL] = new SolidBrush(Color.Black);
            solidBrush[PANEL_SELECTED] = new SolidBrush(Color.White);

            ValuePoint = new Point(TileSize / 2, TileSize / 2);

            NotePoint = new Point[Const.MAXTEK];
            int d = TileSize / 5;
            NotePoint[0] = new Point(d, d);
            NotePoint[1] = new Point(TileSize - d, d);
            NotePoint[2] = new Point(TileSize / 2, TileSize / 2);
            NotePoint[3] = new Point(d, TileSize - d);
            NotePoint[4] = new Point(TileSize - d, TileSize - d);

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
        private TekSolverNotes _notes;
        public TekSolverNotes Notes { get { return _notes; } }
        private void SetBoard(TekBoard value)
        {
            board = value;
            _notes = new TekSolverNotes(value);
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
            const int PADDING = 6;
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
                    newP.Notes = Notes.GetNotes(r, c);
                    newP.NormalColor = AreaColors[AreaColorIndex[newP.Field.area.AreaNum]];
                    newP.SelectedColor = SelectedAreaColors[AreaColorIndex[newP.Field.area.AreaNum]];
                    newP.Click += new EventHandler(Panel_Click);
                    //                    newP.KeyDown+= new EventHandler(Panel_KeyDown);
                    this.Controls.Add(newP);
                    _Panels[r, c] = newP;
                }
            this.Width = PADDING + Board.Cols * data.TileSize;
            this.Height = PADDING + Board.Rows * data.TileSize;
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
        public enum TekBorderStyle { tbsNone, tbsInternal, tbsExternal, tbsBoard, tbsSelected };

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
        private List <int>_notes;
        public List<int> Notes {  get { return _notes;  } set { _notes = value; } }

        public void ToggleNote(int value)
        {
            if (Notes.Contains(value))
                Notes.Remove(value);
            else Notes.Add(value);
            Refresh();
        }
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
            if (Field != null && Field.initial)
                return;
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
        {
            DrawBorderType(e, TekBorderStyle.tbsInternal);
            DrawBorderType(e, TekBorderStyle.tbsExternal);
            DrawBorderType(e, TekBorderStyle.tbsBoard);
        }

        private void DrawBorderType(PaintEventArgs e, TekBorderStyle BS)
        {
            for (TekBorder border = TekBorder.bdTop; border < TekBorder.bdLast; border++)
            {
                if (IsSelected)
                    DrawSingleBorder(e, border, TekBorderStyle.tbsSelected);
                else if (Borders[(int)border] == BS)
                    DrawSingleBorder(e, border, BS);                   
            }
        }

        private void DrawSingleBorder(PaintEventArgs e, TekBorder border, TekBorderStyle BS)
        {
            //tbsNone, tbsInternal, tbsExternal, tbsBoard, tbsSelected
            int[] penSizes = { 0, 1, 1, 1, 1 };
            int iBS = (int)BS;
            int iBorder = (int)border;
            System.Drawing.Color[] bColors = { Color.White, Color.DarkGray, Color.Black, Color.Black, Color.AntiqueWhite };

            int pensize = penSizes[iBS];


            int[] X1 = { 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Width - 1, 0 };
            int[] X2 = { e.ClipRectangle.Width - 1, e.ClipRectangle.Width - 1, 0, 0 };
            int[] Y1 = { 0, 0, e.ClipRectangle.Height - 1, e.ClipRectangle.Height - 1 };
            int[] Y2 = { 0, e.ClipRectangle.Height - 1, e.ClipRectangle.Height - 1, 0 };
            if (pensize > 1)
            {
                int pensize2 = pensize / 2;
                switch (border)
                {
                     case TekBorder.bdTop:
                        Y1[iBorder] += pensize2; Y2[iBorder] += pensize2;
                        break;
                    case TekBorder.bdLeft: 
                         X1[iBorder] += pensize2; X2[iBorder] += pensize2;
                        break;
                }               
            }
            e.Graphics.DrawLine(new Pen(new SolidBrush(bColors[iBS]), pensize), X1[iBorder], Y1[iBorder], X2[iBorder], Y2[iBorder]);
        }
        private void DisplayNote(PaintEventArgs e, int value)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            Data.SetCenterAlignment();
            e.Graphics.DrawString(value.ToString(),
                Data.ValueFont[TekPanelData.FONT_NOTE],
                    Data.solidBrush[IsSelected ? TekPanelData.PANEL_SELECTED : TekPanelData.PANEL_NORMAL],
                    Data.NotePoint[value-1], Data.Format);
        }

        private void DisplayNotes(PaintEventArgs e)
        {
            if (Field != null && Field.Value == 0 && Notes.Count > 0)
            {
                foreach (int value in Notes)
                    DisplayNote(e, value);
            }
        }
        private void DisplayValue(PaintEventArgs e)
        {
            if (Field != null && Field.Value > 0)
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                Data.SetCenterAlignment();
                e.Graphics.DrawString(Field.Value.ToString(),
                    Data.ValueFont[field.initial ? TekPanelData.FONT_INITIAL : TekPanelData.FONT_NORMAL],
                        Data.solidBrush[IsSelected ? TekPanelData.PANEL_SELECTED : TekPanelData.PANEL_NORMAL],
                        Data.ValuePoint, Data.Format);
            }

        }
        protected override void OnPaint(PaintEventArgs e)
        {            
            base.OnPaint(e);
            DisplayValue(e);
            DisplayNotes(e);
            DrawBorders(e);
        }
    }
    
}
