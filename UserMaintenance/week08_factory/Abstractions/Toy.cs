using System;
using System.Drawing;
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
            this.Click += Toy_Click;
            this.Top = 100;
        }
        #endregion

        #region Event handlers
        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        private void Toy_Click(object sender, System.EventArgs e)
        {
            //ShowToyType();
            ToyClicked?.Invoke(this, new ToyTypeEventArgs() { ToyName = ShowToyType() });
        }
        #endregion

        #region Anstract methods
        protected abstract void DrawImage(Graphics input);
        protected abstract string ShowToyType();
        #endregion

        #region Events
        public event EventHandler<ToyTypeEventArgs> ToyClicked;
        #endregion

        #region Public methods
        public virtual void MoveToy()
        {
            this.Left++;
        }
        #endregion
    }
}
