using System;
using System.Diagnostics;


internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            var processes = Process.GetProcesses();  

            foreach (var process in processes)
            {
                Console.WriteLine($"{process.Id} {process.ProcessName}");
            }

            Console.WriteLine("1. New task");
            Console.WriteLine("2. End task");
            Console.WriteLine("3. Exit");
            Console.Write("Make choice: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Input process name: ");
                        var newTask = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(newTask))
                        {
                            throw new Exception("Invalid input");
                            Console.ReadKey();
                        }

                        Process.Start(newTask);
                        Process.GetProcessesByName(newTask);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "2":
                    try
                    {
                        Console.Write("Input process ID: ");
                        var endTask = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(endTask))
                        {
                            throw new Exception("Invalid input");
                        }

                        if (!int.TryParse(endTask, out int id))
                        {
                            throw new Exception("Invalid input");
                        }

                        bool getProcess = false;

                        foreach (var process in processes)
                        {
                            if (process.Id == id)
                            {
                                process.Kill();
                                getProcess = true;
                                break;
                            }
                        }

                        if (!getProcess)
                        {
                            Console.WriteLine($"Process not found");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "3":
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}
