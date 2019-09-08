using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TicTacToeExample.View;

namespace TicTacToeExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Fields
        List<Page> pages = new List<Page>();
        #endregion

        #region Constructors
        public MainWindow()
        {
            pages.Add(new Mvc());
            pages.Add(new Mvp());
            pages.Add(new Mvvm());

            InitializeComponent();
        }
        #endregion

        #region EventMethods
        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(String.Constants.GithubUrl);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = (e.Source) as ListView;

            MainFrame.Navigate(pages[listView.SelectedIndex]);
        }
        #endregion
    }
}
