using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week08_factory.Entities;

namespace week08_factory
{
    public partial class Form1 : Form
    {
        #region Fields
        private List<Ball> _balls = new List<Ball>();
        private BallFactory _factory;
        #endregion

        #region Properties
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            _factory = new BallFactory();
        }
        #endregion

        #region Timer event handlers
        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int pos = 0;
            foreach (Ball b in _balls)
            {
                b.MoveBall();
                if (b.Left > pos)
                {
                    pos = b.Left;
                }                
            }
            if (pos >= 1000)
            {
                Ball toDelete = _balls[0];
                _balls.Remove(toDelete);
                mainPanel.Controls.Remove(toDelete);
            }
        }
        private void createTimer_Tick(object sender, EventArgs e)
        {
            Ball b = Factory.CreateNew();
            b.Left = -b.Width;
            _balls.Add(b);
            mainPanel.Controls.Add(b);
        }
        #endregion
    }
}
