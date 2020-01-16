using System;
using System.Diagnostics;
using System.Threading.Tasks;
using dotnet_project_helper.lib.Models;

namespace dotnet_project_helper.lib.Services
{
    public class CommandExecutor
    {
        private ProcessStartInfo processstartInfo;

        private Process process;

        private string Command
        {
            set
            {
                this.processstartInfo.Arguments = $"-c \"{value}\"";
            }
        }

        public CommandExecutor()
        {
            //sets the default settings
            processstartInfo = new ProcessStartInfo()
            {
                FileName = "/bin/bash",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process = new Process()
            {
                StartInfo = this.processstartInfo
            };
        }

        public async Task<CommandResult> Execute(Command command)
        {
            this.Command = command.Value;

            try
            {
                process.Start();
                return new CommandResult(await process.StandardOutput.ReadToEndAsync());
            }
            catch (Exception e)
            {
                return new CommandResult(e.Message);
            }
        }
    }
}