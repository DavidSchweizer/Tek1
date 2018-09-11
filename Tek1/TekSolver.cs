using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek1
{
    public class TekFieldComparer : IComparer<TekField>
    {
        public int Compare(TekField x, TekField y)
        {
            if (x.PossibleValues.Count == 0 && y.PossibleValues.Count == 0)
                return 0;
            else if (x.PossibleValues.Count == 0)
                return 1;
            else if (y.PossibleValues.Count == 0)
                return -1;
            else if (x.PossibleValues.Count < y.PossibleValues.Count)
                return -1;
            else if (x.PossibleValues.Count > y.PossibleValues.Count)
                return 1;
            else
                return 0;
        }
    }

    class TekSolverNotes
    {
        private TekBoard board;
        public TekBoard Board { get { return board; }}
        private List<int>[,] _notes; // possible values per field
        public List<int> GetNotes(int row, int col) { return _notes[row, col]; }
        public void SetNotes(int row, int col, int value, bool onoff = true)
        {
            if (value >= 1 && value <= Const.MAXTEK)
            {
                if (onoff)
                    _notes[row, col].Add(value);
                else
                    _notes[row, col].Remove(value);
            }
        }
        public TekSolverNotes(TekBoard aboard)
        {
            SetBoard(aboard);
        }

        public void SetDefaultNotes()
        {
            if (Board == null)
                return;
            for (int row = 0; row < Board.Rows; row++)
                for (int col = 0; col < Board.Cols; col++)
                {
                    _notes[row, col].Clear();
                    foreach (int value in Board.values[row, col].PossibleValues)
                        SetNotes(row, col, value, true);
                }
        }
        public void ClearNotes()
        {
            if (Board == null)
                return;
            for (int row = 0; row < Board.Rows; row++)
                for (int col = 0; col < Board.Cols; col++)
                {
                    _notes[row, col].Clear();

                }
        }
        public void ClearNotes(int row, int col)
        {
            if (Board == null)
                return;
            if (row >= 0 && row < Board.Rows && col >= 0 && col < Board.Cols)
                _notes[row, col].Clear();
        }
        private void SetBoard(TekBoard aboard)
        {
            board = aboard;

            if (Board != null)
            {
                _notes = new List<int>[Board.Rows, Board.Cols];
                for (int row = 0; row < Board.Rows; row++)
                    for (int col = 0; col < Board.Cols; col++)
                        _notes[row, col] = new List<int>();
            }
        }
        public void Dump(StreamWriter sw)
        {
            sw.WriteLine("notes:");
            for (int row = 0; row < Board.Rows; row++)
                for (int col = 0; col < Board.Cols; col++)
                {
                    List<int> notes = GetNotes(row, col);
                    if (notes.Count > 0)
                    {
                        TekField field = Board.values[row, col];
                        sw.Write("{0}: ", field.AsString());
                        foreach (int value in notes)
                        sw.Write("{0} ", value);
                        sw.WriteLine();
                    }
                }
        }
    }

    class TekSolver
    {
        private TekBoard board;
        public TekBoard Board { get { return board; } set { SetBoard(value); } }

        private List<TekField> SortedFields;
        private TekFieldComparer sorter;
        private Stack<int[,]> _stack;

        public TekSolver(TekBoard board)
        {
            SortedFields = new List<TekField>();
            sorter = new TekFieldComparer();
            Board = board;
            _stack = new Stack<int[,]>();
        }

        public void PushState()
        {
            _stack.Push(Board.CopyValues());
        }

        public void PopState()
        {
            Board.LoadValues(_stack.Pop());
        }

        private void SetBoard(TekBoard aboard)
        {
            board = aboard;
            
            SortedFields.Clear();
            if (Board != null)
            {
                foreach (TekField field in Board.values)
                    SortedFields.Add(field);
            }
            SortFields();          
        }

        public void SortFields()
        {
            SortedFields.Sort(sorter);
        }

        public void Dump(StreamWriter sw)
        {
            sw.WriteLine("sorted fields:");
            foreach (TekField field in SortedFields)
            {
                field.Dump(sw, TekField.FLD_DMP_POSSIBLES);                                
            }
        }

        private void SetFieldValue(TekField field, int value)
        {
            field.Value = value;
            SortFields();
        }
        public bool SimpleSolve()
        {
            bool result = false;
            while (SortedFields[0].PossibleValues.Count == 1)
            {
                int i = 0;
                result = true;
                while (i < SortedFields.Count && SortedFields[0].PossibleValues.Count == 1)
                    SortedFields[i].Value = SortedFields[i].PossibleValues[0];
                SortFields();
            }
            return result && Board.IsSolved();
        }
        StreamWriter sw = new StreamWriter("debug.log");
        public bool BruteForceSolve()
        {

            TekField Field0 = SortedFields[0];
            sw.WriteLine("trying: {0}", Field0.AsString());
            sw.Flush();
            if (Field0.PossibleValues.Count == 0)
                return Board.IsSolved();
            for (int i = 0; i < Field0.PossibleValues.Count; i++)
            {
                SetFieldValue(Field0, Field0.PossibleValues[i]);
                if (BruteForceSolve())
                    return true;
                else // backtrack 
                    SetFieldValue(Field0, 0);
            } // if we get here, this branch has no solution
            return false;
        }
        public bool Solve()
        {
            bool result = false;
            while (!result)
            {
                if (!SimpleSolve() && !BruteForceSolve())
                    break;
                result = Board.IsSolved();
            }
            return result;
        }
    }
}
