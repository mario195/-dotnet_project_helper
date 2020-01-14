namespace dotnet_project_helper.lib.Services
{
    public class Parameter
    {
        public string ApplicationType { get; set; }

        public bool GitInit { get; set; }

        public bool TestProject { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public void DisplayParameter()
        {
            System.Console.WriteLine("Generating Project with the following Parameter:");
            System.Console.WriteLine("-------------------------------------------------");
            System.Console.WriteLine($"Application name: {this.Name}");
            System.Console.WriteLine($"Application path: {this.Path}");
            System.Console.WriteLine($"Application type: {this.ApplicationType}");
            System.Console.WriteLine($"Generate Test Project? {this.TestProject}");
            System.Console.WriteLine($"Generate Git Repo? {this.GitInit}");
        }
    }
}