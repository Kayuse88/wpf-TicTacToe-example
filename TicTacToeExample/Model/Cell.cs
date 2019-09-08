using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.Model
{
    // Eric Maxwell의 TicTacToe 참고.
    // https://github.com/ericmaxwell2003/ticTacToe
    class Cell
    {
        private Player? value;

        public Player? GetValue()
        {
            return value;
        }

        public void SetValue(Player player)
        {
            value = player;
        }
    }
}
