using System;
using Xunit;
using dotnet_project_helper.lib.Services;
using System.Threading.Tasks;
using dotnet_project_helper.lib.Models;

namespace dotnet_project_helper.test
{
    public class CommandExecutorTest
    {
        CommandExecutor executor;

        public CommandExecutorTest()
        {
            executor = new CommandExecutor();
        }

        [Fact]
        public async Task ShouldReturnTypeCommandResult()
        {
            var command = new Command("ls");

            var result = await executor.Execute(command);

            Assert.IsType<CommandResult>(result);
        }

        [Fact]
        public async Task ShouldExecuteCommandAndReturnOutput()
        {
            var command = new Command("echo Hello World");

            var result = (await executor.Execute(command)).Result;

            Assert.Equal("Hello World\n", result);
        }
    }
}