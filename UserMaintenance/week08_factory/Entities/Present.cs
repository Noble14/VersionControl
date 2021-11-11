﻿using System;
using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    class Present : Toy
    {
        #region Properties
        public SolidBrush RibbonColor { get; private set; }
        public SolidBrush BoxColor { get; private set; }
        #endregion

        #region Constructor
        public Present(Color ribbon, Color box)
        {
            BoxColor = new SolidBrush(box);
            RibbonColor = new SolidBrush(ribbon);
        }
        #endregion

        #region Protected methods
        protected override void DrawImage(Graphics input)
        {
            input.FillRectangle(BoxColor, new RectangleF(0, 0, Width, Height));
            int n = Width / 10;
            input.FillRectangle(RibbonColor, new Rectangle((Width - n) / 2, 0, n, Height));
            int m = Height / 10;
            input.FillRectangle(RibbonColor, new Rectangle(0, (Height - m) / 2, Width, m));
        }

        protected override string ShowToyType()
        {
            return "Ajándék";
        }
        #endregion
    }
}
