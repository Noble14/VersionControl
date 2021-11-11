using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }

        #region Constructor
        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
        }
        #endregion

        #region Protected methods
        protected override void DrawImage(Graphics input)
        {
            input.FillEllipse(BallColor, 0, 0, Width, Height);
        }
        #endregion
    }
}
