using System;

namespace UnitSystem.Examples
{
    public class Box : IHasVolume, IHasMass
    {
        private readonly Shape3D shape = new Cuboid("3m", "4m", "5m");

        public Box()
        {

        }

        public Volume Volume => shape.Volume;

        public Mass Mass => throw new NotImplementedException();

        public Density Density => throw new NotImplementedException();
    }
}
