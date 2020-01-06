using TicTacToeExample.Model;
using Xunit;

namespace TicTacToeExample.Test.Model
{
    public class BoardTests
    {
        private Board testBoard;

        public BoardTests()
        {
            testBoard = new Board();
        }

        [Fact]
        public void RestartTest()
        {
            MarkXasWin();

            testBoard.Restart();

            Assert.Null(testBoard.GetWinner());
        }

        private void MarkXasWin()
        {
            testBoard.Mark(0, 0);
            testBoard.Mark(1, 1);
            testBoard.Mark(0, 1);
            testBoard.Mark(1, 2);
            testBoard.Mark(0, 2);
        }

        [Fact]
        public void MarkOutOfBound()
        {
            var player = testBoard.Mark(0, 4);

            Assert.Null(player);
        }

        [Fact]
        public void MarkMarkedCell()
        {
            testBoard.Mark(1, 1);

            var player = testBoard.Mark(1, 1);

            Assert.Null(player);
        }

        [Fact]
        public void MarkIfFinishedGame()
        {
            MarkXasWin();

            var player = testBoard.Mark(2, 2);

            Assert.Null(player);
        }
    }
}
