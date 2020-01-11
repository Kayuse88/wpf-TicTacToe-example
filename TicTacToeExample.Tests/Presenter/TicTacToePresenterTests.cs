using Moq;
using TicTacToeExample.Presenter;
using Xunit;

namespace TicTacToeExample.Test.Presenter
{
    public class TicTacToePresenterTests
    {
        public TicTacToePresenterTests()
        {
            viewMock = new Mock<ITicTacToeView>();
            var dummyView = viewMock.Object;

            testpresenterImpl = new TicTacToePresenterImpl(dummyView);
        }

        private readonly TicTacToePresenterImpl testpresenterImpl;
        private readonly Mock<ITicTacToeView> viewMock;

        private void MarkXasWinner(TicTacToePresenterImpl presenter)
        {
            presenter.ButtonSelected(0, 0);
            presenter.ButtonSelected(1, 1);
            presenter.ButtonSelected(0, 1);
            presenter.ButtonSelected(1, 2);
            presenter.ButtonSelected(0, 2);
        }

        [Fact]
        public void ButtonSelectedTest()
        {
            testpresenterImpl.ButtonSelected(1, 1);

            viewMock.Verify(mock => mock.SetButtonText(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()),
                Times.Once);
        }

        [Fact]
        public void ResetTest()
        {
            testpresenterImpl.Reset();

            viewMock.Verify(mock => mock.ClearWinnerDisplay());
            viewMock.Verify(mock => mock.ClearButtons());
        }

        [Fact]
        public void ShowWinnerTest()
        {
            MarkXasWinner(testpresenterImpl);

            viewMock.Verify(mock => mock.ShowWinner("X"), Times.Once);
        }
    }
}