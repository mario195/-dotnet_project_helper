using System.Collections.Generic;
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
                    new SwitchArgument('t', "--test", false),
                    new ValueArgument<string>('p', "path", string.Empty),
                    new EnumeratedValueArgument<string>('a', "apptype", new string[]{
                    "console","api","mvc"
                })
            }
            };
        }

        public void Parse(string[] args)
        {
            this.parser.ParseCommandLine(args);

            parser.ShowParsedArguments();

            // if (parser.ParsingSucceeded)
            // {
            //     var parameter = new Parameter();
            //     parser.

            // }
            // else
            // {

            // }
        }
    }
}