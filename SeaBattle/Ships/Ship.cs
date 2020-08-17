namespace SeaBattle
{
    using System;
    using System.Drawing;
    public abstract class Ship
    {
        public string Index { get; set; }
        public int Lenght { get; set; }
        public int Range { get; set; }
        public byte Quadrant { get; set; }
        public double CenterDistance { get; set; }
        public Point Coordinates { get; set; }
        public bool IsPoint { get; set; }
        public ShipType Type { get; set; }
        public float Speed { get; set; }
        public int Dx { get; set; }
        public int Dy { get; set; }


        public void CompareTo(object obj)
        {
            Ship ship = (Ship)obj;
            if (this.Type == ship.Type && ship.IsPoint && this.IsPoint)
            {
                Console.WriteLine("This ships are equals");
            }
            else
            {
                Console.WriteLine("This ships are not equals");
            }
        }
    }
}
