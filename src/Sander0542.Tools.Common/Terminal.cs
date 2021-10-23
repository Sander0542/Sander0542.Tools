using System.Diagnostics;

namespace Sander0542.Tools.Common
{
    public static class Terminal
    {
        public static bool Run(string command, string args, string workingDirectory, int successCode = 0)
        {
            using var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = args,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardError = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                CreateNoWindow = true,
                StandardErrorEncoding = null,
                StandardOutputEncoding = null
            };

            process.Start();
            process.WaitForExit();

            return process.ExitCode == successCode;
        }
    }
}
