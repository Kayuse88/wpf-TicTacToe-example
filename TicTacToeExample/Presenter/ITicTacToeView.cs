namespace TicTacToeExample.Presenter
{
    // Refer to Maxwell's TicTacToe.
    // https://github.com/ericmaxwell2003/ticTacToe
    public interface ITicTacToeView
    {
        void ShowWinner(string winningPlayerDisplayLabel);
        void ClearWinnerDisplay();
        void ClearButtons();
        void SetButtonText(int row, int col, string text);
    }
}
