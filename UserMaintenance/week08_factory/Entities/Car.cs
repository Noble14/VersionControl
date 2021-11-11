using System;
using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    class Car : Toy
    {
        #region Protected methods
        protected override void DrawImage(Graphics input)
        {
            Image img = Image.FromFile("Images/car.png");
            input.DrawImage(img, new Rectangle(0, 0, Width, Height));
        }

        protected override string ShowToyType()
        {
            return "Autó";
        }
        #endregion
    }
}
