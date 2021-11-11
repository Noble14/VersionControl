using System;
using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        Random vel = new Random();

        #region Constructor
        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
            this.Click += Ball_Click;
        }
        #endregion

        #region Event handlers
        private void Ball_Click(object sender, System.EventArgs e)
        {
            Color c = Color.FromArgb(vel.Next(256), vel.Next(256), vel.Next(256));
            BallColor.Color = c;
            Invalidate();
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
