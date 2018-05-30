using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain.Commands
{
    public class ReportCommand:Command
    {
        public override string Execute(Robot robot, params string[] args)
        {
            return robot.Report();
        }
        public override bool IsValid()
        {
            return true;
        }
    }
}
