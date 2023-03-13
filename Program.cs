using System;
using System.IO;

namespace FarManagerDemo;

class Program
{
    static void Main()
    {
        string path = Path.GetPathRoot(Environment.SystemDirectory); 

        Console.WriteLine("-----Welcome-----");
        Console.WriteLine($"Current directory: {path}");

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1.- List all directories");
            Console.WriteLine("2.- Copy file");
            Console.WriteLine("3.- Move file");
            Console.WriteLine("4.- Exit");
            Console.Write("> ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListDirectories(path);
                    break;
                case "2":
                    Console.Write("Enter the file path you want to copy: ");
                    string sourceFilePath = Console.ReadLine();
                    Console.Write("Enter the destination path: ");
                    string destinationPath = Console.ReadLine();
                    CopyFile(sourceFilePath, destinationPath);
                    break;
                case "3":
                    Console.Write("Enter the file path you want to move: ");
                    string moveSourceFilePath = Console.ReadLine();
                    Console.Write("Enter the destination path: ");
                    string moveDestinationPath = Console.ReadLine();
                    MoveFile(moveSourceFilePath, moveDestinationPath);
                    break;
                case "4":
                    Console.WriteLine("Exiting");
                    return;
                default:
                    Console.WriteLine("Enter the number in the range 1-4");
                    break;
            }
        }
    }

    static void ListDirectories(string path)
    {
        try
        {
            Console.WriteLine($"All directories in {path}:");
            string[] directories = Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                Console.WriteLine(directory);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    static void CopyFile(string sourceFilePath, string destinationPath)
    {
        try
        {
            string sourceFileName = Path.GetFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(destinationPath, sourceFileName);
            File.Copy(sourceFilePath, destinationFilePath);
            Console.WriteLine($"Successfully copied {sourceFileName} to {destinationPath}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }

    static void MoveFile(string sourceFilePath, string destinationPath)
    {
        try
        {
            string sourceFileName = Path.GetFileName(sourceFilePath);
            string destinationFilePath = Path.Combine(destinationPath, sourceFileName);
            File.Move(sourceFilePath, destinationFilePath);
            Console.WriteLine($"Successfully moved {sourceFileName} to {destinationPath}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"{e.Message}");
        }
    }
}
