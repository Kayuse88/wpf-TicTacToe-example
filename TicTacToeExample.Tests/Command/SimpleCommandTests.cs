using System;
using TicTacToeExample.Command;
using Xunit;

namespace TicTacToeExample.Test.Command
{
    public class SimpleCommandTests
    {
        private readonly SimpleCommand testCommand;
        private readonly SimpleCommand<string> genericTestCommand;
        private event EventHandler<EventArgs> TestHandler;
        private object param = "string";

        public SimpleCommandTests()
        {
            testCommand = new SimpleCommand(dummyMethod);
            genericTestCommand = new SimpleCommand<string>(mockMethod);
        }

        private void dummyMethod()
        {
            TestHandler?.Invoke(this, new EventArgs());
        }

        private void mockMethod(string parameter)
        {
            TestHandler?.Invoke(this, new EventArgs());
        }

        [Fact]
        public void CanExecuteTest()
        {
            Assert.True(testCommand.CanExecute(new object()));
            Assert.True(genericTestCommand.CanExecute(param));
        }

        [Fact]
        public void ExecuteTest()
        {
            Assert.Raises<EventArgs>(handler => TestHandler += handler, handler => TestHandler -= handler,
                () => testCommand.Execute());

            Assert.Raises<EventArgs>(handler => TestHandler += handler, handler => TestHandler -= handler,
                () => genericTestCommand.Execute(param));
        }

        [Fact]
        public void NullMethodTest()
        {
            Assert.Throws<ArgumentNullException>(() => new SimpleCommand(null));
            Assert.Throws<ArgumentNullException>(() => new SimpleCommand<string>(null));
        }
    }
}