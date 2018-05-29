using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    /// <summary>
    /// This class represents Robots position in 2D world
    /// </summary>
    public class Position
    {
        public Position(Coordinate coordinate, Direction direction)
        {
            Coordinate = coordinate;
            Direction = direction;
        }

        public Direction Direction { get; private set; }

        public Coordinate Coordinate { get; private set; }
    }
}
