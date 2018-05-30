using RobotSimulator.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    /// <summary>
    /// This class is responsible for parsing text input to commands
    /// </summary>
    public class InputParser:IDisposable
    {
        private char[] commandDelimiter = { ' ' };
        private int commandIndex = 0;
        private static Dictionary<string, Command> registeredCommands = null;

        public InputParser()
        {
            registeredCommands =  RegisterCommands();
        }

        /// <summary>
        /// Parse the input for command and arguments string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="command"></param>
        /// <param name="commandArgs"></param>
        public void TryParse(string input,out Command command,out string commandArgs)
        {
            command = new NullCommand();
            commandArgs = string.Empty;

            if (!string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input))
            {
                string[] commandText = input.Split(commandDelimiter, StringSplitOptions.RemoveEmptyEntries);
                if (commandText.Length > 0)
                {
                    string commandKey = commandText[commandIndex].ToLower();
                    string args = commandText.Length > 1 ? commandText[commandIndex + 1] : string.Empty;

                    if (registeredCommands.ContainsKey(commandKey))
                    {
                        command = registeredCommands[commandKey];
                        commandArgs = args;
                    }
                }
            }

        }

        protected virtual Dictionary<string, Command> RegisterCommands()
        {
           var commands = new Dictionary<string, Command>();
            commands.Add("place", new PlaceCommand());
            commands.Add("move", new MoveCommand());
            commands.Add("left", new LeftCommand());
            commands.Add("right", new RightCommand());
            commands.Add("report", new ReportCommand());
            return commands;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    registeredCommands = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~InputParser() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
