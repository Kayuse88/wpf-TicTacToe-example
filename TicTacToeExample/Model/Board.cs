using static TicTacToeExample.Model.Players;

namespace TicTacToeExample.Model
{
    // Eric Maxwell의 TicTacToe 참고.
    // https://github.com/ericmaxwell2003/ticTacToe
    class Board
    {
        private Cell[,] cells = new Cell[3, 3];

        private Player? winner;
        private GameState state;
        private Player currentTurn;

        private enum GameState { IN_PROGRESS, FINISHED }

        public Board()
        {
            Restart();
        }

        public void Restart()
        {
            ClearCells();
            winner = null;
            currentTurn = Player.X;
            state = GameState.IN_PROGRESS;
        }

        public Player? Mark(int row, int col)
        {
            Player? playerThatMoved = null;

            if (IsValid(row, col))
            {

                cells[row, col].SetValue(currentTurn);
                playerThatMoved = currentTurn;

                if (IsWinningMoveByPlayer(currentTurn, row, col))
                {
                    state = GameState.FINISHED;
                    winner = currentTurn;
                }
                else
                {
                    FlipCurrentTurn();
                }
            }

            return playerThatMoved;
        }

        public Player? GetWinner()
        {
            return winner;
        }

        private void ClearCells()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    cells[i, j] = new Cell();
                }
            }
        }

        private bool IsValid(int row, int col)
        {
            if (state == GameState.FINISHED)
            {
                return false;
            }
            else if (IsOutOfBounds(row) || IsOutOfBounds(col))
            {
                return false;
            }
            else if (IsCellValueAlreadySet(row, col))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool IsOutOfBounds(int idx)
        {
            return idx < 0 || idx > 2;
        }

        private bool IsCellValueAlreadySet(int row, int col)
        {
            return cells[row, col].GetValue() != null;
        }


        private bool IsWinningMoveByPlayer(Player player, int currentRow, int currentCol)
        {
            return (cells[currentRow, 0].GetValue() == player         // 3-in-the-row
                    && cells[currentRow, 1].GetValue() == player
                    && cells[currentRow, 2].GetValue() == player
                    || cells[0, currentCol].GetValue() == player      // 3-in-the-column
                    && cells[1, currentCol].GetValue() == player
                    && cells[2, currentCol].GetValue() == player
                    || currentRow == currentCol            // 3-in-the-diagonal
                    && cells[0, 0].GetValue() == player
                    && cells[1, 1].GetValue() == player
                    && cells[2, 2].GetValue() == player
                    || currentRow + currentCol == 2    // 3-in-the-opposite-diagonal
                    && cells[0, 2].GetValue() == player
                    && cells[1, 1].GetValue() == player
                    && cells[2, 0].GetValue() == player);
        }

        private void FlipCurrentTurn()
        {
            currentTurn = currentTurn == Player.X ? Player.O : Player.X;
        }
    }
}
