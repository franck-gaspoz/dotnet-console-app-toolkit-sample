//#define catch_exceptions

using System;
using static DotNetConsoleSdk.Component.CommandLine.CommandLineProcessor;
using static DotNetConsoleSdk.DotNetConsole;

namespace DotNetConsoleSdkSample
{
    class Program
    {
        static void Main(string[] args)
        {
#if catch_exceptions
            try
            {
#endif
                InitializeCommandProcessor(args);
                if (HasArgs)
                    Print(Arg(0));
                else
                {
                //RunSampleCLI("(f=yellow,exec=[[System.IO.Path.GetFileName(System.Environment.CurrentDirectory)]]) > ");
                //var returnCode = TerminalSample.Run(new string[] { "help" ,"-v","find" }, "(f=yellow)> ");
                //var returnCode = TerminalSample.Run(new string[] { "find","c:","-file","*.txt" }, "(f=yellow)> ");
                //var returnCode = TerminalSample.Run(new string[] { "find","c:","-file","filename","-contains","content" }, "(f=yellow)> ");
                //var returnCode = TerminalSample.Run(new string[] { "find" ,"-file","xx"}, "(f=yellow)> ");
                var returnCode = TerminalSample.Run(new string[] { "find" ,"c:\\"}, "(f=yellow)> ");
                Environment.Exit(returnCode);
                }
#if catch_exceptions
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
#endif
        }
    }
}
