namespace dotnet_project_helper.lib.Services
{
    public class Command
    {
        public Command(string command)
        {
            Value = command;
        }

        public Command()
        {

        }

        public string Value { get; set; }
    }
}