using System;

namespace SeaBattle
{
    public abstract class Ship : IComparable
    {
        public int Index { get; set; }
        public int Lenght { get; set; }
        public int Range { get; set; }
        public byte Quadrant { get; set; }
        public bool IsPoint { get; set; }
        public ShipType Type { get; set; }
        public float Speed { get; set; }
        public int Dx { get; set; }
        public int Dy { get; set; }


        public int CompareTo(object obj)
        {
            return Lenght.CompareTo(obj);
        }
    }
}
