using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSimulator.Domain
{
    /// <summary>
    /// This immutable class represents Robots position in 2D world
    /// </summary>
    public class Position:IDisposable
    {
        private readonly Coordinate coordinate;
        private readonly Direction direction;
        public Position(Coordinate coordinate, Direction direction)
        {
            this.coordinate = coordinate;
            this.direction = direction;
        }

        public Direction Direction { get { return direction; } }

        public Coordinate Coordinate { get { return coordinate; } }

        public override string ToString()
        {
            return Coordinate.ToString()+","+Direction.ToString();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Position() {
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
