using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain.Commands
{
    public class PlaceCommand:Command
    {
        private char[] paramDelimiter = { ',' };
        public override string Execute(Robot robot,params string[] args)
        {
            string[] parameters = args.FirstOrDefault().Split(paramDelimiter, StringSplitOptions.RemoveEmptyEntries);
            int x = Int32.Parse(parameters[0]);
            int y = Int32.Parse(parameters[1]);
            string strdirection = parameters[2]?.TrimEnd();

            if (string.IsNullOrEmpty(strdirection))
                return string.Empty;

            Coordinate newCoordinate = new Coordinate(x, y);
            Direction newDirection = ParseDirection(strdirection);

            robot.Place(newCoordinate, newDirection);

            return string.Empty;
        }
        public override bool IsValid()
        {
            return true;
        }
        protected Direction ParseDirection(string strDirection)
        {
            Direction direction;
            switch (strDirection.ToLower())
            {
                case "north":
                    direction = new North();
                    break;
                case "south":
                    direction = new South();
                    break;
                case "east":
                    direction = new East();
                    break;
                case "west":
                    direction = new West();
                    break;
                default:
                    direction = new North();
                    break;
            }
            return direction;
        }
    }
}
