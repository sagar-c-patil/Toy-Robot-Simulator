using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain.Commands
{
    public abstract class Command
    {
        public abstract string Execute(Robot robot,params string[] args);
        public abstract bool IsValid();
        
    }
}
