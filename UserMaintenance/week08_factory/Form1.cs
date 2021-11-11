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
        private Toy _nextToy;
        #endregion

        #region Properties
        public IToyFactory Factory
        {
            get { return _factory; }
            set
            {
                _factory = value;
                DisplayNext();
            }
        }
        #endregion

        #region Constructor
        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
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

        #region Menu event handlers

        private void _buttonCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void _buttonBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory()
            {
                BallColor = _buttonColorPick.BackColor
            };

        }

        private void _buttonColorPick_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ColorDialog cd = new ColorDialog();
            cd.Color = button.BackColor;
            if (cd.ShowDialog() == DialogResult.OK)
                button.BackColor = cd.Color;
        }

        private void _buttonPresent_Click(object sender, EventArgs e)
        {
            Factory = new PresentFactory()
            {
                BoxColor = buttonBox.BackColor,
                RibbonColor = buttonRibbon.BackColor
            };
        }
        #endregion

        #region Private methods
        private void DisplayNext()
        {
            if (_nextToy != null)
            {
                _panelMenu.Controls.Remove(_nextToy);
            }
            _nextToy = _factory.CreateNew();
            _nextToy.Top = _labelComingNext.Height + _labelComingNext.Top;
            _nextToy.Left = _labelComingNext.Left;
            _panelMenu.Controls.Add(_nextToy);
        }
        #endregion


    }
}
