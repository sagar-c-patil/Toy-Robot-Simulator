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
    public class Surface:IDisposable
    {
        Coordinate origin = null;
        Coordinate boundary = null;
        public Surface(int width, int height)
        {
            origin = new Coordinate(0, 0);
            boundary = new Coordinate(width, height);
        }

        public bool IsValidCoordinate(Coordinate newCoordinate)
        {
            if (newCoordinate == null)
                return false;

            return !(origin.IsOutSideOrigin(newCoordinate))
                && !(boundary.IsOutSideBoundary(newCoordinate));
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
        // ~Surface() {
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
