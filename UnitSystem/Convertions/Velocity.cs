using System;

namespace UnitSystem
{
    public readonly partial struct Velocity
    {
        //public static Accelaration operator /(Velocity velocity, Time time)
        //{
        //    throw new NotImplementedException();
        //    return new Accelaration(velocity.Value / time.Value);
        //}

        public static Length operator *(Velocity velocity, Time time)
        {
            return new Length(velocity.Value * time.Value);
        }
    }
}
