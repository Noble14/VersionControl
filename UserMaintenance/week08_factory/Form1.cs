using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using week08_factory.Entities;
using week08_factory.Abstractions;

namespace week08_factory
{
    public partial class Form1 : Form
    {
        #region Fields
        private List<Toy> _toys = new List<Toy>();
        private IToyFactory _factory;
        #endregion

        #region Properties
        public IToyFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            _factory = new CarFactory();
        }
        #endregion

        #region Timer event handlers
        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            int pos = 0;
            foreach (Toy b in _toys)
            {
                b.MoveToy();
                if (b.Left > pos)
                {
                    pos = b.Left;
                }                
            }
            if (pos >= 1000)
            {
                Toy toDelete = _toys[0];
                _toys.Remove(toDelete);
                mainPanel.Controls.Remove(toDelete);
            }
        }
        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy b = Factory.CreateNew();
            b.Left = -b.Width;
            _toys.Add(b);
            mainPanel.Controls.Add(b);
        }
        #endregion
    }
}
