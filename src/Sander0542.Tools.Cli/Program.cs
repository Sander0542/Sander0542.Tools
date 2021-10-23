using System;
using McMaster.Extensions.CommandLineUtils;

namespace Sander0542.Tools.Cli
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                return CommandLineApplication.Execute<MainCommand>(args);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
        }
    }
}
