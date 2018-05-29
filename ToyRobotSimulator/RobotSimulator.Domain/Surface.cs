using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    /// <summary>
    /// This class represents all the attributes and behaviour of surface
    /// </summary>
    public class Surface
    {
        Coordinate origin = null;
        Coordinate boundary = null;
        public Surface()
        {
            origin = new Coordinate(0, 0);
            boundary = new Coordinate(4, 4);
        }

        public bool IsValidCoordinate(Coordinate newCoordinate)
        {
            if (newCoordinate == null)
                return false;

            return !(origin.IsOutSideOrigin(newCoordinate)
                && boundary.IsOutSideBoundary(newCoordinate));
        }

       
    }
}
