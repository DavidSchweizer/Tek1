using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tek1
{
    public enum TekMove { tmValue, tmNote, tmClear };

    class TekPlay
    {
        private int _row;
        private int _col;
        private TekMove _move;
        private int _value;
        private List<int> _notes;
        public int Row { get { return _row; } }
        public int Col { get { return _col; } }
        public int Value { get { return _value; } }
        public List<int> Notes { get { return _notes; } } 
        public TekMove Move { get { return _move; } }
        public TekPlay(int row, int col, TekMove move, int value, List<int> notes = null)
        {
            _row = row;
            _col = col;
            _move = move;
            _value = value;
            if (notes == null)
                _notes = null;
            else
            {
                _notes = new List<int>();
                foreach (int i in notes)
                    _notes.Add(i);
            }
        }
    }

    class TekMoves
    {
        private TekBoard _board;
        public TekBoard Board { get { return _board; } }

        private Stack<TekPlay> _moves;
        protected Stack<TekPlay> Moves { get { return _moves; } }

        public TekMoves(TekBoard board)
        {
            _moves = new Stack<TekPlay>();
            _board = board;
        }

        private void PushMove(int row, int col, TekMove move, int value)
        {
            if (move == TekMove.tmClear)
                Moves.Push(new TekPlay(row, col, TekMove.tmClear, value, Board.values[row, col].Notes));
            else
                Moves.Push(new TekPlay(row, col, move, value));
        }

        public void PlayValue(int row, int col, int value)
        {
            PushMove(row, col, TekMove.tmValue, value);
            Board.values[row, col].ToggleValue(value);
        }

        public void PlayNote(int row, int col, int value)
        {
            PushMove(row, col, TekMove.tmNote, value);
            Board.values[row, col].ToggleNote(value);
        }

        public void PlayClear(int row, int col)
        {
            PushMove(row, col, TekMove.tmClear, Board.values[row,col].Value);
            Board.values[row, col].ClearNotes();
            if (!Board.values[row,col].initial)
                Board.values[row, col].Value = 0;
        }

        public void UnPlay()
        {
            if (Moves.Count() > 0)
            {
                TekPlay move = Moves.Pop();
                switch (move.Move)
                {
                    case TekMove.tmValue:
                        Board.values[move.Row, move.Col].ToggleValue(move.Value);
                        break;
                    case TekMove.tmNote:
                        Board.values[move.Row, move.Col].ToggleNote(move.Value);
                        break;
                    case TekMove.tmClear:
                        Board.values[move.Row, move.Col].ToggleValue(move.Value);
                        foreach (int i in move.Notes)
                            Board.values[move.Row, move.Col].ToggleNote(i);
                        break;
                }
            }
        }
        public void Clear()
        {
            Moves.Clear();
        }
    }
}
