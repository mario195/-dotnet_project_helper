using System;
using System.Diagnostics;
using System.Threading.Tasks;
using dotnet_project_helper.lib.Models;

namespace dotnet_project_helper.lib.Services
{
    public class CommandExecutor
    {
        private ProcessStartInfo processstartInfo;

        private string Command
        {
            get
            {
                if (this.processstartInfo.Arguments != null)
                {
                    return this.processstartInfo.Arguments;
                }
                else
                {
                    return string.Empty;
                }
            }
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
        }

        public CommandExecutor(string command) : this()
        {
            this.Command = command;
        }

        public async Task<CommandResult> Execute(Command command)
        {
            this.Command=command.Value;

            var process = new Process()
            {
                StartInfo = this.processstartInfo
            };

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