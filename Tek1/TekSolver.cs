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

    class TekSolver
    {
        private TekBoard board;
        public TekBoard Board { get { return board; } set { SetBoard(value); } }

        private List<TekField> SortedFields;
        private TekFieldComparer sorter;
        
        public TekSolver(TekBoard board)
        {
            SortedFields = new List<TekField>();
            sorter = new TekFieldComparer();
            Board = board;
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
                field.Dump(sw, TekField.FLD_DMP_POSSIBLES);
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
            return result;
        }
    }
}
