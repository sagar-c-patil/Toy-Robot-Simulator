using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain.Commands
{
    public abstract class Command
    {
        public abstract string Execute();
        public abstract bool IsValid { get; set; }
    }
}
