using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Coordinate(int x,int y)
        {
            X = x;
            Y = y;
        }

        public bool IsOutSideOrigin(Coordinate newCoordinate)
        {
            return (this.X >= newCoordinate.X && this.Y >= newCoordinate.Y);
        }

        public bool IsOutSideBoundary(Coordinate newCoordinate)
        {
            return (this.X <= newCoordinate.X && this.Y <= newCoordinate.Y);
        }
    }
}
