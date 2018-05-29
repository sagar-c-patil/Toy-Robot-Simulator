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
            System.Console.WriteLine("Started - Toy Robot Simulator - Please press ESC anytime to quit");
            System.Console.WriteLine("--------------------------------------------------------------");

            while (System.Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                var input = System.Console.ReadLine();
               
            }
        }
    }
}
