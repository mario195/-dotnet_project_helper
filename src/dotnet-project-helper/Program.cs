using dotnet_project_helper.Services;

namespace dotnet_project_helper
{
    class Program
    {
        static async System.Threading.Tasks.Task<int> Main(string[] args)
        {
            var parser = new CliArgsParser();

            if (args.Length == 0)
            {
                parser.ShowUsage();
                
                return 1;
            }
            else
            {
                parser.Parse(args);

                var generator = new ProjectGenerator(parser, new CommandExecutor());

                await generator.Create();
            }

            return 0;
        }
    }
}
