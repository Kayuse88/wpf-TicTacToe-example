namespace TicTacToeExample.Presenter
{
    // Refer to Maxwell's TicTacToe.
    // https://github.com/ericmaxwell2003/ticTacToe
    interface ITicTacToePresenter
    {
        void ButtonSelected(int row, int col);
        void Reset();
    }
}
