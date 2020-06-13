//#define catch_exceptions

using DotNetConsoleAppToolkit.Component.CommandLine;
using DotNetConsoleAppToolkit.Component.CommandLine.CommandLineReader;
using System;
using static DotNetConsoleAppToolkit.DotNetConsole;

namespace DotNetConsoleAppToolkitSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandLineProcessor = new CommandLineProcessor(args);
            if (commandLineProcessor.HasArgs)
            {
                var commandLineReader = new CommandLineReader(commandLineProcessor);
                commandLineReader.ProcessCommandLine(
                    string.Join(' ', args),
                    commandLineProcessor.Eval);
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
