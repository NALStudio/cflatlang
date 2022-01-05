﻿using CMM.Core;
using CMM.Language;
using CMM.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CMM;

public static class Program
{
    public static int Main(string[] args)
    {
        if (args.Length < 1 || args[0] == "help")
        {
            ConsoleUtility.WriteUsage();
            return 0;
        }

        #region Initialisations
        LanguageData.Init();
        #endregion

        string command = args[0];
        CMM_Program program;
        try
        {
            program = CMM_Program.Create(args[1..]);
        }
        catch (Exception ex)
        {
            ConsoleUtility.WriteError(ex.Message);
            return 1;
        }

        return command switch
        {
            "int" => Interpret(program),
            "com" => CompileToFile(program).exitCode,
            "run" => Run(program),
            "check" => Compile(program),
            _ => InvalidCommandError(command)
        };
    }

    private static int InvalidCommandError(string command)
    {
        ConsoleUtility.WriteError($"Invalid command: \"{command}\"");
        return 1;
    }


    private static int Run(CMM_Program program)
    {
        (string outputPath, int exitCode) = CompileToFile(program);
        if (exitCode != 0)
            return exitCode;

        Process runProcess = Process.Start(outputPath);
        runProcess.WaitForExit();
        return runProcess.ExitCode;
    }

    private static int Compile(CMM_Program program)
    {
        throw new NotImplementedException();
    }

    private static (string path, int exitCode) CompileToFile(CMM_Program program)
    {
        throw new NotImplementedException();
    }

    private static int Interpret(CMM_Program program)
    {
        throw new NotImplementedException();
    }
}