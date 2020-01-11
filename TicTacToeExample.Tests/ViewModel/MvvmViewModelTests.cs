using TicTacToeExample.ViewModel;
using static TicTacToeExample.Model.Players;
using Xunit;

namespace TicTacToeExample.Test.ViewModel
{
    public class MvvmViewModelTests
    {
        private readonly MvvmViewModel mvvmViewModel;

        public MvvmViewModelTests()
        {
            mvvmViewModel = new MvvmViewModel();
        }

        [Fact]
        public void CellCommandTest()
        {
            mvvmViewModel.CellCommand.Execute("12");

            Assert.Equal(Player.X ,mvvmViewModel.Cells[5].Marker);
        }

        [Fact]
        public void ResetCommandTest()
        {
            mvvmViewModel.CellCommand.Execute("12");
            mvvmViewModel.ResetCommand.Execute(null);

            Assert.Null(mvvmViewModel.Cells[5].Marker);
        }

        [Fact]
        public void GetWinner()
        {
            MarkXasWinner();

            Assert.Equal("X", mvvmViewModel.Winner);
        }

        private void MarkXasWinner()
        {
            mvvmViewModel.CellCommand.Execute("00");
            mvvmViewModel.CellCommand.Execute("11");
            mvvmViewModel.CellCommand.Execute("01");
            mvvmViewModel.CellCommand.Execute("12");
            mvvmViewModel.CellCommand.Execute("02");
        }
    }
}
