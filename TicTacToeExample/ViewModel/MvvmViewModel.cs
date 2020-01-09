using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using TicTacToeExample.Command;
using TicTacToeExample.Model;
using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.ViewModel
{
    public class MvvmViewModel : ViewModelBase
    {
        #region Fields
        private string _winner;
        private ObservableCollection<Cell> _cells;
        private Board _model;
        #endregion

        #region Properties
        public string Winner
        {
            get { return _winner; }
            set
            {
                _winner = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Cell> Cells
        {
            get { return _cells; }
            set
            {
                _cells = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public ICommand CellCommand { get; set; }
        public ICommand ResetCommand { get; set; }
        #endregion

        #region Constructors
        public MvvmViewModel()
        {
            _model = new Board();
            Cells = new ObservableCollection<Cell>();

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Cells.Add(new Cell(i, j));

            CellCommand = new SimpleCommand<string>(CellSelect);
            ResetCommand = new SimpleCommand(Reset);
        }
        #endregion

        #region Methods
        private void CellSelect(string parameter)
        {
            int row = Convert.ToInt32(parameter.Substring(0, 1));
            int col = Convert.ToInt32(parameter.Substring(1, 1));

            Debug.WriteLine("Click on Row: " + row + " Col: " + col, String.Constants.Mvvm);

            Player? playerThatMoved = _model.Mark(row, col);

            if (playerThatMoved != null)
            {
                Cells[row * 3 + col].Marker = playerThatMoved;
                Winner = _model.GetWinner() == null ? null : _model.GetWinner().ToString();
            }
        }

        private void Reset()
        {
            foreach (var cell in Cells)
            {
                cell.Marker = null;
            }
            Winner = null;
            _model.Restart();
        }
        #endregion
    }
}
