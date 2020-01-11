using TicTacToeExample.Model;
using Xunit;
using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.Test.Model
{
    public class CellTests
    {
        private readonly Cell testCell;

        public CellTests()
        {
            testCell = new Cell(1, 1);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(500, 0)]
        public void MakeCellTest(int x, int y)
        {
            var newCell = new Cell(x, y);

            var fact = string.Concat(x, y);

            Assert.Equal(fact, newCell.RowCol);
        }

        [Theory]
        [InlineData(Player.O)]
        [InlineData(Player.X)]
        public void MarkerTest(Player player)
        {
            testCell.Marker = player;

            Assert.Equal(player, testCell.Marker);
        }
    }
}
