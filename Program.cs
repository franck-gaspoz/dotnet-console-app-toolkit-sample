using System;
using static DotNetConsoleSdk.Component.CommandLine.CommandEngine;
using static DotNetConsoleSdk.DotNetConsole;

namespace DotNetConsoleSdkSample
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeCommandEngine(args);
            if (HasArgs)
                Print(Arg(0));
            else
            {
                //RunSampleCLI("(f=yellow,exec=[[System.IO.Path.GetFileName(System.Environment.CurrentDirectory)]]) > ");
                var returnCode = TerminalSample.Run(args, "(f=yellow)> ");
                Environment.Exit(returnCode);
            }
        }
    }
}
