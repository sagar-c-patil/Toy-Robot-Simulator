using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    /// <summary>
    /// Set of classes to represent unique directions
    /// </summary>
    public abstract class Direction
    {
        protected int stepSize = 1;
        public abstract int XStep { get; set; }
        public abstract int YStep { get; set; }

        public abstract Direction Left { get; }
        public abstract Direction Right { get; }
    }

    public class North : Direction
    {
        public override int XStep { get; set; }
        public override int YStep { get; set; }
        public override Direction Left
        {
            get { return new West(); }
        }
        public override Direction Right
        {
            get { return new East(); }
        }
        public North()
        {
            XStep = 0;
            YStep = stepSize;           
        }
        public override string ToString()
        {
            return "NORTH";
        }
    }

    public class South : Direction
    {
        public override int XStep { get; set; }
        public override int YStep { get; set; }
        public override Direction Left
        {
            get { return new East(); }
        }
        public override Direction Right
        {
            get { return new West(); }
        }
        public South()
        {
            XStep = 0;
            YStep = -stepSize;
        }
        public override string ToString()
        {
            return "SOUTH";
        }
    }

    public class East : Direction
    {
        public override int XStep { get; set; }
        public override int YStep { get; set; }
        public override Direction Left
        {
            get { return new North(); }
        }
        public override Direction Right
        {
            get { return new South(); }
        }
        public East()
        {
            XStep = stepSize;
            YStep = 0;
        }
        public override string ToString()
        {
            return "EAST";
        }
    }

    public class West : Direction
    {
        public override int XStep { get; set; }
        public override int YStep { get; set; }
        public override Direction Left
        {
            get { return new South(); }
        }
        public override Direction Right
        {
            get { return new North(); }
        }
        public West()
        {
            XStep = -stepSize;
            YStep = 0;
        }
        public override string ToString()
        {
            return "WEST";
        }
    }
}
