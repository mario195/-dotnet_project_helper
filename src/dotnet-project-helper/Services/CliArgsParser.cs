using System.Collections.Generic;
using System.Linq;
using CommandLineParser.Arguments;

namespace dotnet_project_helper.Services
{
    public class CliArgsParser
    {
        private CommandLineParser.CommandLineParser parser;

        public CliArgsParser()
        {
            this.parser = new CommandLineParser.CommandLineParser()
            {
                Arguments = new List<Argument>(){
                    new SwitchArgument('g', "gitinit", false),
                    new SwitchArgument('t', "test", false),
                    new ValueArgument<string>('p', "path","Fully qualified name of the project"),
                    new EnumeratedValueArgument<string>('a', "apptype","Type of application (webapi, console, mvc)" ,new string[]{
                    "console","webapi","mvc"
                })
            }
            };
        }

        public void Parse(string[] args)
        {
            this.parser.ParseCommandLine(args);

            var r = this.getAppType;
        }

        public string getAppType
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "apptype")
                   as EnumeratedValueArgument<string>).Value;
            }
        }

        public bool createGitRepo
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "gitinit")
                    as SwitchArgument).Value;
            }
        }

        public bool createTestProject
        {
            get
            {
                return (parser.Arguments.SingleOrDefault(x => x.LongName == "test")
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