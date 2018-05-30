using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain.Commands
{
    public class LeftCommand:Command
    {
        public override string Execute(Robot robot,params string[] args)
        {
            robot.RotateLeft();
            return string.Empty;
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
