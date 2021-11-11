using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    public class BallFactory : IToyFactory
    {
        public Color BallColor { get; set; }

        #region Public methods
        public Toy CreateNew()
        {
            return new Ball(BallColor);
        }
        #endregion
    }
}
