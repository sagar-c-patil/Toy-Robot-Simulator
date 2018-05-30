using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    /// <summary>
    /// This class has all behaviour implementation for robot
    /// It requires surface on which it will be deployed
    /// </summary>
    public class Robot:IDisposable
    {
        private Surface surface;
        private Position currentPosition;
        public Position CurrentPosition { get { return this.currentPosition; } }

        public Robot(Surface surface){
            this.surface = surface;
        }

        public void Place(Coordinate coordinate,Direction direction)
        {
            if(surface.IsValidCoordinate(coordinate))
                this.currentPosition = new Position(coordinate, direction);
        }
        public string Report()
        {
            return currentPosition!=null
                ? "Output: "+currentPosition.ToString():string.Empty;
        }
        public void RotateLeft()
        {
            if(this.currentPosition!=null)
                this.currentPosition = new Position(this.currentPosition.Coordinate, this.currentPosition.Direction.Left);
        }
        public void RotateRight()
        {
            if (this.currentPosition != null)
                this.currentPosition = new Position(this.currentPosition.Coordinate, this.currentPosition.Direction.Right);
        }

        /// <summary>
        /// Moves robot forward to current direction
        /// It calculates new position and checkes if its within Range of surface
        /// </summary>
        public void Move()
        {
            if (this.currentPosition != null)
            {
                Coordinate newCoordinateAfterMove 
                    = new Coordinate(this.currentPosition.Coordinate.X + this.currentPosition.Direction.XStep,
                    this.currentPosition.Coordinate.Y + this.currentPosition.Direction.YStep);

                /// Verify surface boundary conditions before move.Ignore command if it doesn't meet criteria

                if (surface.IsValidCoordinate(newCoordinateAfterMove))
                {
                    this.currentPosition = new Position(newCoordinateAfterMove, this.currentPosition.Direction);
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.surface.Dispose();
                    this.currentPosition.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Robot() {
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
