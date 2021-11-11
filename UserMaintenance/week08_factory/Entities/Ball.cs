using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week08_factory.Entities
{
    class Ball : Label
    {
        #region Constructor
        public Ball()
        {
            this.AutoSize = false;
            this.Width = 50;
            this.Height = 50;
            this.Paint += Ball_Paint;
        }
        #endregion

        #region Event handler
        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        #endregion

        #region Protected methods
        protected void DrawImage(Graphics input)
        {
            SolidBrush p = new SolidBrush(Color.Blue);
            input.FillEllipse(p, 0, 0, Width, Height);
        }
        #endregion

        #region Public methods
        public void MoveBall()
        {
            this.Left++;
        }
        #endregion
    }
}
