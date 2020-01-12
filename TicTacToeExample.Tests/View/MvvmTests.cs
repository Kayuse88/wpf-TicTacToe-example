using TicTacToeExample.View;
using Xunit;

namespace TicTacToeExample.Test.View
{
    public class MvvmTests
    {
        private Mvvm view;

        [WpfFact]
        public void CreateTest()
        {
            view = new Mvvm();
        
            Assert.NotNull(view);
        }
    }
}