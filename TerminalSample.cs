using DotNetConsoleSdk.Component.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static DotNetConsoleSdk.Component.Shell.Terminal;
using static DotNetConsoleSdk.Component.CommandLine.CommandEngine;
using static DotNetConsoleSdk.DotNetConsole;
using sc = System.Console;
using static DotNetConsoleSdk.Lib.Str;
using DotNetConsoleSdk.Component.Shell;
using System.Diagnostics;

namespace DotNetConsoleSdkSample
{
    public static class TerminalSample
    {
        static void InitializeUI()
        {
            Clear();
            SetWorkArea("shell.input",0, 4, -1, -3);

            AddFrame((frame) =>
            {
                var s = "".PadLeft(frame.ActualWidth, '-');
                var t = $" dotnet-console-sdk - terminal sample [{Environment.OSVersion} {(Environment.Is64BitOperatingSystem?"64":"32")}bits]";
                return new List<string> {
                        $"{Bdarkblue}{Cyan}{s}",
#pragma warning disable IDE0071
#pragma warning disable IDE0071WithoutSuggestion
                        $"{Bdarkblue}{Cyan}|{t}{White}{"".PadLeft(Math.Max(0, frame.ActualWidth - 2 - t.Length))}{Cyan}|",
#pragma warning restore IDE0071WithoutSuggestion
#pragma warning restore IDE0071
                        $"{Bdarkblue}{Cyan}{s}"
                    };
            }, ConsoleColor.DarkBlue, 0, 0, -1, 3, DrawStrategy.OnViewResizedOnly, false);

            string GetCurrentDriveInfo()
            {
                var rootDirectory = Path.GetPathRoot(Environment.CurrentDirectory);
                var di = DriveInfo.GetDrives().Where(x => x.RootDirectory.FullName == rootDirectory).FirstOrDefault();
                return (di == null) ? "?" : $"{rootDirectory} {HumanFormatOfSize(di.AvailableFreeSpace, 0, "")}/{HumanFormatOfSize(di.TotalSize, 0, "")} ({di.DriveFormat})";
            }

            AddFrame((frame) =>
            {
                return new List<string> {
                        $"{Bdarkblue} {Green}cur: {Cyan}{CursorLeft},{CursorTop}{White}"
                        +$" | {Green}win: {Cyan}{sc.WindowLeft},{sc.WindowTop}"
                        +$",{sc.WindowWidth},{sc.WindowHeight}{White}"
                        //+$" | {(sc.CapsLock?$"{Cyan}Caps":$"{Darkgray}Caps")}"        // not supported on linux (ubuntu 18.04 wsl)
                        //+$" {(sc.NumberLock?$"{Cyan}Num":$"{Darkgray}Num")}{White}"   // not supported on linux (ubuntu 18.04 wsl)
                        +$" | {Green}in={Cyan}{sc.InputEncoding.CodePage}"
                        +$" {Green}out={Cyan}{sc.OutputEncoding.CodePage}{White}"
                        +$" | {Green}drive: {Cyan}{GetCurrentDriveInfo()}{White}"
                        +$" | {Cyan}{System.DateTime.Now}{White}      "
                    };
            },
            // use w=-2 to prevent print a car at bottom right of the window that lead to scroll on main terminals (ore else use AvoidConsoleAutoLineBreakAtEndOfLine=true) 
            ConsoleColor.DarkBlue, 0, -1, -2, 1, DrawStrategy.OnTime, false, 1000);

            SetCursorAtBeginWorkArea();
        }

        public static int Run(string[] args,string? prompt = null)
        {
            try
            {
                InitializeCommandEngine(args);
                InitializeTerminal(Eval);
                InitializeUI();

                SendInput(string.Join(' ', args));
                var retCode = Terminal.Readln(prompt,false);
                WaitReadln();
                return retCode;
            }
            catch (Exception initException)
            {
                LogError(initException);
                Exit(ReturnCodeError);
            }
            return ReturnCodeError;
        }
    }
}
