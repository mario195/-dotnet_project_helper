namespace dotnet_project_helper.Services
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