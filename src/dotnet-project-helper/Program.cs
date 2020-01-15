using dotnet_project_helper.lib.Services;

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
                var parameter = parser.Parse(args);

                parameter.DisplayParameter();

                var generator = new DefaultProjectGenerator(parser);

                await generator.Create();
            }

            return 0;
        }
    }
}
