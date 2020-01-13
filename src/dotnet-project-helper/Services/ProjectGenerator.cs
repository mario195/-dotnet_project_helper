using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_project_helper.Services
{
    public class ProjectGenerator
    {
        private CliArgsParser parser;

        private CommandExecutor executor;

        private List<Command> commands;

        public ProjectGenerator(CliArgsParser parser, CommandExecutor executor)
        {
            this.executor = executor;

            this.parser = parser;

            commands = new List<Command>();

            commands.Add(new Command { Value = $"mkdir {this.parser.getFullPath}" });

            commands.Add(new Command { Value = $"mkdir {this.parser.getFullPath}/src" });

            commands.Add(new Command { Value = $"dotnet new {this.parser.getAppType} -o {this.parser.getFullPath}/src/test" });

            if (parser.createGitRepo)
            {
                commands.Add(new Command { Value = $"dotnet new gitignore -o {parser.getFullPath}" });

                commands.Add(new Command { Value = $"git init {this.parser.getFullPath}" });
            }
        }

        public async Task Create()
        {
            foreach (Command command in commands)
            {
                await executor.Execute(command);
            }
        }
    }
}