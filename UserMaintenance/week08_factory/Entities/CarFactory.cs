using week08_factory.Abstractions;

namespace week08_factory.Entities
{
    class CarFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
