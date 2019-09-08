using TicTacToeExample.Model;
using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.Presenter
{
    class TicTacToePresenterImpl : ITicTacToePresenter
    {
        #region Fields
        private readonly Board model;
        private readonly ITicTacToeView view;
        #endregion

        #region Constructors
        public TicTacToePresenterImpl(ITicTacToeView view)
        {
            this.model = new Board();
            this.view = view;
        }
        #endregion

        #region ITacTacToePresenter Implementation
        public void ButtonSelected(int row, int col)
        {
            Player? playerThatMoved = model.Mark(row, col);

            if (playerThatMoved != null)
            {
                view.SetButtonText(row, col, playerThatMoved.ToString());

                if (model.GetWinner() != null)
                {
                    view.ShowWinner(playerThatMoved.ToString());
                }
            }
        }

        public void Reset()
        {
            view.ClearWinnerDisplay();
            view.ClearButtons();
            model.Restart();
        }
        #endregion
    }
}
