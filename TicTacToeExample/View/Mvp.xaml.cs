using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TicTacToeExample.Presenter;

namespace TicTacToeExample.View
{
    // Refer to Maxwell's TicTacToe.
    // https://github.com/ericmaxwell2003/ticTacToe
    /// <summary>
    /// Interaction logic for Mvp.xaml
    /// </summary>
    public partial class Mvp : Page, ITicTacToeView
    {
        #region Fields
        private readonly ITicTacToePresenter presenter;
        #endregion

        #region Constructors
        public Mvp()
        {
            InitializeComponent();

            presenter = new TicTacToePresenterImpl(this);
        }
        #endregion

        #region EventMethods
        private void TicTacToe_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            int row = Convert.ToInt32((button.Name).Substring(7, 1));
            int col = Convert.ToInt32((button.Name).Substring(8, 1));

            Debug.WriteLine("Click on Row: " + row + " Col: " + col, String.Constants.Mvp);

            presenter.ButtonSelected(row, col);
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.Reset();
        }
        #endregion

        #region ITicTacToeView Implementation
        public void ShowWinner(string winningPlayerDisplayLabel)
        {
            TextBlock_Winner.Text = winningPlayerDisplayLabel;
            StackPanel_Winner.Visibility = Visibility.Visible;
        }

        public void ClearWinnerDisplay()
        {
            StackPanel_Winner.Visibility = Visibility.Hidden;
            TextBlock_Winner.Text = "";
        }

        public void ClearButtons()
        {
            for (int i = 0; i < WrapPanel_ButtonGrid.Children.Count; i++)
            {
                ((Button)WrapPanel_ButtonGrid.Children[i]).Content = "";
            }
        }

        public void SetButtonText(int row, int col, string text)
        {
            Button button = FindName("Button_" + row + col) as Button;
            if (button != null)
            {
                button.Content = text;
            }
        }
        #endregion
    }
}
