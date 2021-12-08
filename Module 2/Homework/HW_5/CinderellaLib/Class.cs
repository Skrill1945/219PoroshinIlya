using System;

namespace CinderellaLib
{
    public abstract class Something
    {
    }

    public class Ashes : Something
    {
        private double _volume;

        public Ashes(double a)
        {
            if (a > 0 && a < 1) _volume = a;
            else _volume = 0;
        }
        public override string ToString()
        {
            return $"Ashes {_volume}";
        }
    }

    public class Lentil : Something
    {
        private double _weight;

        public Lentil(double a)
        {
            if (a > 0 && a < 2) _weight = a;
            else _weight = 0;
        }

        public override string ToString()
        {
            return $"Lentil {_weight}";
        }
    }

}
