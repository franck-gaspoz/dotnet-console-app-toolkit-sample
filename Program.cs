//#define catch_exceptions

using System;
using static DotNetConsoleSdk.Component.CommandLine.CommandLineProcessor;
using static DotNetConsoleSdk.DotNetConsole;
using DotNetConsoleSdk.Component.CommandLine.CommandLineReader;

namespace DotNetConsoleSdkSample
{
    class Program
    {
        static void Main(string[] args)
        {

            if (HasArgs)
            {
                var commandLineReader = new CommandLineReader();
                InitializeCommandProcessor(args, commandLineReader);
                commandLineReader.ProcessCommandLine(
                    string.Join(' ', args),
                    Eval);
            }
            else
            {
                var prompt = $"{Green}> ";
                //RunSampleCLI("(f=yellow,exec=[[System.IO.Path.GetFileName(System.Environment.CurrentDirectory)]]) > ");
                //var returnCode = TerminalSample.Run(new string[] { "help" ,"-v","find" }, prompt);
                //var returnCode = TerminalSample.Run(new string[] { "find","c:","-file","*.txt" }, prompt);
                //var returnCode = TerminalSample.Run(new string[] { "find","c:","-file","filename","-contains","content" }, prompt);
                //var returnCode = TerminalSample.Run(new string[] { "help" }, prompt);
                //var returnCode = TerminalSample.Run(new string[] { "find" , @"""c:\\documents and settings""" , "-attr" , "-top"}, prompt);
                //var returnCode = TerminalSample.Run(new string[] { "find" , "c:\\" , "-pat" , "*.sys" , "-attr" , "-top"}, prompt);
                //var returnCode = TerminalSample.Run("find d:\\ -attr -dir -pat *prestashop*", prompt);
                //var returnCode = TerminalSample.Run("module -load \"C: \Users\franc\Documents\Visual Studio 2019\Projects\Applications\dotnet-console-sdk\dotnet-console-sdk-sample\bin\Debug\netcoreapp3.1\dotnet-console-sdk.dll\"", prompt);
                var returnCode = TerminalSample.Run("", prompt);
                Environment.Exit(returnCode);
            }
        }
    }
}
