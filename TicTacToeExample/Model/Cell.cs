using TicTacToeExample.ViewModel;
using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.Model
{
    // Eric Maxwell의 TicTacToe 참고.
    // https://github.com/ericmaxwell2003/ticTacToe
    public class Cell : ViewModelBase
    {
        private Player? _marker;

        public string RowCol { get; private set; }
        public Player? Marker
        {
            get { return _marker; }
            set
            {
                _marker = value;
                NotifyPropertyChanged();
            }
        }

        public Cell()
        {
        }

        public Cell(int row, int col)
        {
            string rowcol = "" + row + col;
            RowCol = rowcol;
        }
    }
}
