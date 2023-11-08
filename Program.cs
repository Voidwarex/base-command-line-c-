using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<string, Action> commands = new Dictionary<string, Action>();

    static void Main(string[] args)
    {
        commands["/help"] = ShowHelp;

        while (true)
        {
            Console.Write("Enter a command: ");
            string input = Console.ReadLine();

            if (string.IsNullOrEmpty(input))
                continue;

            if (commands.TryGetValue(input, out Action action))
            {
                action.Invoke();
            }
            else
            {
                Console.WriteLine("Command not found. Type '/help' for a list of commands.");
            }
        }
    }

    static void ShowHelp()
    {
        Console.WriteLine("Available commands:");
        foreach (var command in commands.Keys)
        {
            Console.WriteLine(command);
        }
    }
}
