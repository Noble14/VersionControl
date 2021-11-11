using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week08_factory.Entities
{
    public class BallFactory
    {
        #region Public methods
        public Ball CreateNew()
        {
            return new Ball();
        }
        #endregion
    }
}
