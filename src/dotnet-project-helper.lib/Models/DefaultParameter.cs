using dotnet_project_helper.lib.Interfaces;

namespace dotnet_project_helper.lib.Models
{
    public class DefaultParameter : IParameter
    {
        public string ApplicationType { get; set; }

        public bool GitInit { get; set; }

        public bool TestProject { get; set; }

        public bool VerboseOutput { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public void DisplayParameter()
        {
            System.Console.WriteLine("Generating Project with the following Parameter:");
            System.Console.WriteLine("------------------------------------------------");
            System.Console.WriteLine($"Application name: {this.Name}");
            System.Console.WriteLine($"Application path: {this.Path}");
            System.Console.WriteLine($"Application type: {this.ApplicationType}");
            System.Console.WriteLine($"Generate Test Project? {(this.TestProject ? "Yes" : "No")}");
            System.Console.WriteLine($"Generate Git Repo? {(this.GitInit ? "Yes" : "No")}");
            System.Console.WriteLine($"Verbose output? {(this.VerboseOutput ? "On" : "Off")}");
            System.Console.WriteLine("------------------------------------------------");
        }
    }
}