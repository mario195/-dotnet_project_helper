using System;
using System.Diagnostics;

namespace dotnet_project_helper
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("/bin/bash", "-c \"dotnet --info\"");

            procStartInfo.RedirectStandardOutput = true;

            procStartInfo.UseShellExecute = false;

            procStartInfo.CreateNoWindow = true;

            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            proc.StartInfo = procStartInfo;

            proc.Start();

            String result = proc.StandardOutput.ReadToEnd();

            System.Console.WriteLine(result);
        }
    }
}
