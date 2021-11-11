﻿using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    public class BallFactory : IToyFactory
    {
        #region Public methods
        public Toy CreateNew()
        {
            return new Ball();
        }
        #endregion
    }
}
