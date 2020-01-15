using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_project_helper.lib.Models;

namespace dotnet_project_helper.lib.Services
{
    public class ProjectGenerator
    {
        private CliArgsParser parser;

        private CommandExecutor executor;

        private List<Command> commands;

        public ProjectGenerator(CliArgsParser parser)
        {
            this.executor = new CommandExecutor();

            this.parser = parser;

            commands = new List<Command>();

            CreateRawProject(commands);

            if (parser.shouldCreateTestProject)
                AddTestProject(commands);

            commands.Add(new Command { 
                Value = $"dotnet sln {parser.getFullPath}/{parser.getAppName}.sln  add {parser.getFullPath}/src/{parser.getAppName}*" });

            if (parser.shouldCreateGitRepo)
                AddGitRepo(commands);
        }

        private void AddGitRepo(List<Command> commands)
        {
            commands.Add(new Command { Value = $"dotnet new gitignore -o {parser.getFullPath}" });

            commands.Add(new Command { Value = $"git init {this.parser.getFullPath}" });

            commands.Add(new Command { Value = $"git -C {parser.getFullPath}/  add . " });

            commands.Add(new Command { Value = $"git -C {parser.getFullPath}/ commit -m 'First commit'" });

        }

        private void AddTestProject(List<Command> commands)
        {
            commands.Add(new Command { Value = $"dotnet new xunit -o {parser.getFullPath}/src/{parser.getAppName}.test" });
        }

        private void CreateRawProject(List<Command> commands)
        {
            commands.Add(new Command { Value = $"mkdir {this.parser.getFullPath}" });

            commands.Add(new Command { Value = $"mkdir {this.parser.getFullPath}/src" });

            commands.Add(new Command { Value = $"dotnet new {this.parser.getAppType}  -o {this.parser.getFullPath}/src/{parser.getAppName}" });

            commands.Add(new Command { Value = $"dotnet new sln -n {parser.getAppName} -o {this.parser.getFullPath}" });
        }

        public async Task Create()
        {
            foreach (Command command in commands)
            {
                var result = await executor.Execute(command);
                
                if (parser.shouldBeVerbose)
                    System.Console.WriteLine(result.Result);
            }

            System.Console.WriteLine("Done!");
        }
    }
}