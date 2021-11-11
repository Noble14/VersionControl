using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week08_factory.Abstractions
{
    public abstract class Toy : Label
    {
        #region Constructor
        public Toy()
        {
            this.AutoSize = false;
            this.Width = 50;
            this.Height = 50;
            this.Paint += Toy_Paint;
        }
        #endregion

        #region Event handler
        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        #endregion

        #region Anstract methods
        public abstract void DrawImage(Graphics input);
        #endregion

        #region Public methods
        public virtual void MoveToy()
        {
            this.Left++;
        }
        #endregion
    }
}
