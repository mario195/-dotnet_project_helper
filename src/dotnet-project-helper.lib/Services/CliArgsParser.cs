using System.Collections.Generic;
using System.Linq;
using CommandLineParser.Arguments;

namespace dotnet_project_helper.lib.Services
{
    public class CliArgsParser
    {
        private CommandLineParser.CommandLineParser parser;

        public CliArgsParser()
        {
            this.parser = new CommandLineParser.CommandLineParser()
            {
                Arguments = new List<Argument>()
                {
                    new SwitchArgument('g', "git-init", false){Optional=true,Description="Should the project be initialized with a git repo?"},
                    new SwitchArgument('t', "test-project", false){Optional=true,Description="Should the project be initialized with a test project?"},
                    new ValueArgument<string>('n',"name","Application name"){Optional=false},
                    new ValueArgument<string>('p', "path","Path to the project"){Optional=false},
                    new EnumeratedValueArgument<string>('a', "apptype","Type of application (webapi, console, mvc)" ,new string[]{
                    "console","webapi","mvc","classlib","blazorserver","web","webapp","angular","react","reactredux"
                }){Optional=false}
            }
            };
        }

        public void ShowUsage() => parser.ShowUsage();


        public Parameter Parse(string[] args)
        {
            this.parser.ParseCommandLine(args);

            return new Parameter()
            {
                ApplicationType = this.getAppType,
                GitInit = this.shouldCreateGitRepo,
                TestProject = this.shouldCreateTestProject,
                Path = this.getFullPath,
                Name = this.getAppName
            };
        }

        public string getAppName
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "name")
                    as ValueArgument<string>).Value;
            }
        }

        public string getAppType
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "apptype")
                   as EnumeratedValueArgument<string>).Value;
            }
        }

        public bool shouldCreateGitRepo
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "git-init")
                    as SwitchArgument).Value;
            }
        }

        public bool shouldCreateTestProject
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "test-project")
                    as SwitchArgument).Value;
            }
        }

        public string getFullPath
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "path")
                     as ValueArgument<string>).Value;
            }
        }
    }
}