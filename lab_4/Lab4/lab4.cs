// Main Console Application
// Project: ConsoleApp

using System;
using ConsoleLibrary;

class Program
{
    /// <summary>
    /// Entry point of the application. Processes command-line arguments and executes the corresponding logic.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        switch (args[0].ToLower()) // Normalize input to lowercase for consistency
        {
            case "version":
                ShowVersionInfo();
                break;
            case "run":
                if (args.Length > 1)
                {
                    RunLab(args);
                }
                else
                {
                    Console.WriteLine("Error: Please specify the lab to run (lab1, lab2, or lab3).\n");
                    ShowHelp();
                }
                break;
            case "set-path":
                if (args.Length > 2 && (args[1] == "-p" || args[1] == "--path"))
                {
                    SetPath(args[2]);
                }
                else
                {
                    Console.WriteLine("Error: Please provide a valid path.\n");
                    ShowHelp();
                }
                break;
            default:
                Console.WriteLine("Error: Unknown command.\n");
                ShowHelp();
                break;
        }
    }

    /// <summary>
    /// Displays version and author information.
    /// </summary>
    static void ShowVersionInfo()
    {
        Console.WriteLine("Author: Your Name");
        Console.WriteLine("Version: 1.0.0");
    }

    /// <summary>
    /// Displays help information for using the application.
    /// </summary>
    static void ShowHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  version             - Displays author and version information.");
        Console.WriteLine("  run [lab1|lab2|lab3] [-I <input file>] [-o <output file>] - Runs the specified lab.");
        Console.WriteLine("  set-path -p <path>  - Sets the LAB_PATH environment variable.");
    }

    /// <summary>
    /// Executes the specified lab with optional input and output file paths.
    /// </summary>
    /// <param name="args">Command-line arguments for the run command.</param>
    static void RunLab(string[] args)
    {
        string lab = args[1].ToLower(); // Normalize lab name to lowercase
        string inputFile = null;
        string outputFile = null;

        for (int i = 2; i < args.Length; i++)
        {
            if ((args[i] == "-I" || args[i] == "--input") && i + 1 < args.Length)
            {
                inputFile = args[++i];
            }
            else if ((args[i] == "-o" || args[i] == "--output") && i + 1 < args.Length)
            {
                outputFile = args[++i];
            }
        }

        string basePath = GetBasePath(inputFile);

        if (string.IsNullOrEmpty(basePath))
        {
            Console.WriteLine("Error: Input file not found. Please specify a valid path.");
            return;
        }

        switch (lab)
        {
            case "lab1":
                Labs.RunLab1(basePath, outputFile);
                break;
            case "lab2":
                Labs.RunLab2(basePath, outputFile);
                break;
            case "lab3":
                Labs.RunLab3(basePath, outputFile);
                break;
            default:
                Console.WriteLine("Error: Unknown lab specified.\n");
                ShowHelp();
                break;
        }
    }

    /// <summary>
    /// Determines the base path for input files based on priority rules.
    /// </summary>
    /// <param name="inputFile">Specified input file path.</param>
    /// <returns>Valid file path or null if not found.</returns>
    static string GetBasePath(string inputFile)
    {
        if (!string.IsNullOrEmpty(inputFile) && System.IO.File.Exists(inputFile))
        {
            return inputFile;
        }

        string labPath = Environment.GetEnvironmentVariable("LAB_PATH");
        if (!string.IsNullOrEmpty(labPath) && System.IO.File.Exists(labPath))
        {
            return labPath;
        }

        string defaultPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "defaultInput.txt");
        if (System.IO.File.Exists(defaultPath))
        {
            return defaultPath;
        }

        return null;
    }

    /// <summary>
    /// Sets the LAB_PATH environment variable to the specified path.
    /// </summary>
    /// <param name="path">Path to set as LAB_PATH.</param>
    static void SetPath(string path)
    {
        if (System.IO.Directory.Exists(path))
        {
            Environment.SetEnvironmentVariable("LAB_PATH", path, EnvironmentVariableTarget.User);
            Console.WriteLine($"LAB_PATH set to: {path}");
        }
        else
        {
            Console.WriteLine("Error: Specified path does not exist.");
        }
    }
}
