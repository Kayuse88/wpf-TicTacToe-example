using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TicTacToeExample.Model;
using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.View
{
    // Refer to Maxwell's TicTacToe.
    // https://github.com/ericmaxwell2003/ticTacToe
    /// <summary>
    /// Interaction logic for Mvc.xaml
    /// </summary>
    public partial class Mvc : Page
    {
        #region Fields
        private Board model;
        #endregion

        #region Constructors
        public Mvc()
        {
            InitializeComponent();

            model = new Board();
        }
        #endregion

        #region Methods
        private void Reset()
        {
            StackPanel_Winner.Visibility = Visibility.Hidden;
            TextBlock_Winner.Text = "";

            model.Restart();

            for (int i = 0; i < WrapPanel_ButtonGrid.Children.Count; i++)
            {
                ((Button)WrapPanel_ButtonGrid.Children[i]).Content = "";
            }
        }
        #endregion

        #region EventMethods
        private void TicTacToe_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            int row = Convert.ToInt32(((string)button.Tag).Substring(0, 1));
            int col = Convert.ToInt32(((string)button.Tag).Substring(1, 1));

            Debug.WriteLine("Click on Row: " + row + " Col: " + col, String.Constants.Mvc);

            Player? playerThatMoved = model.Mark(row, col);

            if (playerThatMoved != null)
            {
                button.Content = playerThatMoved;
                if (model.GetWinner() != null)
                {
                    TextBlock_Winner.Text = playerThatMoved.ToString();
                    StackPanel_Winner.Visibility = Visibility.Visible;
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }
        #endregion
    }
}
