namespace dotnet_project_helper.lib.Interfaces
{
    public interface ICliArgsParser
    {
        IParameter Parse(string[] args);
    }
}