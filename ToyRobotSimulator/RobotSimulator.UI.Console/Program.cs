using RobotSimulator.Domain;
using RobotSimulator.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.UI.Console
{
    /// <summary>
    /// Console UI to take input from standard console and process commands
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.BackgroundColor = ConsoleColor.Blue;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Started - Toy Robot Simulator - Type exit anytime to quit");
            System.Console.WriteLine("--------------------------------------------------------------");
            var parser = new InputParser();
            var table = new Surface(5, 5);
            var toyRobot = new Robot(table);
            while (true)
            {
                var input = System.Console.ReadLine();
                if (input.ToLower().Contains("exit"))
                    Environment.Exit(0);
                parser.TryParse(input, out Command command, out string commandArgs);
                var result = command.Execute(toyRobot, commandArgs);
                System.Console.WriteLine(result);
               
            }           

        }
    }
}
