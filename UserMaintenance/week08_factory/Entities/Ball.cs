using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    public class Ball : Toy
    {
        #region Protected methods
        protected override void DrawImage(Graphics input)
        {
            SolidBrush p = new SolidBrush(Color.Blue);
            input.FillEllipse(p, 0, 0, Width, Height);
        }
        #endregion
    }
}
