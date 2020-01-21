using System.Threading.Tasks;
using dotnet_project_helper.lib.Models;
using dotnet_project_helper.lib.Services;
using Xunit;

namespace dotnet_project_helper.test
{
    public class ProjectGeneratorTest
    {
        DefaultCliArgsParser parser;

        public ProjectGeneratorTest()
        {
            parser = new DefaultCliArgsParser();

            parser.Parse(new[] { "-g", "-t", "-v", "-p", "~/test", "-a", "console", "-n", "new-app" });
        }

        [Fact]
        public async Task ShouldGenerateConsoleApplication()
        {
            var generator = new DefaultProjectGenerator(parser);

            await generator.Create();

            var result = await new CommandExecutor().Execute(new Command { Value = $"cat {parser.getFullPath}/src/{parser.getAppName}/Program.cs " });

            Assert.True(result.Result.Contains("Console.WriteLine(\"Hello World!\");"));

            await RemoveGeneratedProject();
        }

        private async Task RemoveGeneratedProject()
        {
            await new CommandExecutor().Execute(new Command { Value = $"rm -rf {parser.getFullPath}" });
        }
    }
}