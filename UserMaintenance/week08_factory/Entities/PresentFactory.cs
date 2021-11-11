using System.Drawing;
using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    class PresentFactory : IToyFactory
    {
        #region Properties
        public Color RibbonColor { get; set; }
        public Color BoxColor { get; set; }
        #endregion

        public Toy CreateNew()
        {
            return new Present(RibbonColor, BoxColor);
        }
    }
}
