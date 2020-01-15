namespace dotnet_project_helper.lib.Models
{
    public class CommandResult
    {
        public CommandResult(string res)
        {
            Result = res;
        }

        public string Result { get; set; }
    }
}