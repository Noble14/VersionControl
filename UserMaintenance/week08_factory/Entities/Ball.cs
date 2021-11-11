using System;
using System.Drawing;
using System.Windows.Forms;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
        Random vel = new Random();
        private int lowerBound;
        private int upperBound;
        bool upOrdDown;

        #region Constructor
        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
            this.Click += Ball_Click;
            lowerBound = Top;
            upperBound = Top + 30;
            upOrdDown = false;
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

        protected override string ShowToyType()
        {
            return "Labda";
        }

        public override void MoveToy()
        {
            Left++;
            if (lowerBound == Top || upperBound == Top) upOrdDown = !upOrdDown;
            if (upOrdDown)
            {
                Top++;
            }
            else
            {
                Top--;
            }
        }
        #endregion
    }
}
