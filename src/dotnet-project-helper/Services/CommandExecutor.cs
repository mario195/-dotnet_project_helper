using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace dotnet_project_helper.Services
{
    public class CommandExecutor
    {
        private ProcessStartInfo processstartInfo;

        public string Command
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
                this.processstartInfo.Arguments = processstartInfo.Arguments += " " + value;
            }
        }

        public CommandExecutor()
        {
            //sets the default settings
            processstartInfo = new ProcessStartInfo()
            {
                FileName = "/bin/bash",
                Arguments = "-c ",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
        }

        public CommandExecutor(string command) : this()
        {
            this.Command = command;
        }

        public async Task<CommandResult> Execute()
        {
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