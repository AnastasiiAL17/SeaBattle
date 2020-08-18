namespace SeaBattle
{
    public abstract class Ship
    {
        public string Index { get; set; }

        public int Lenght { get; set; }

        public int Range { get; set; }

        public double CenterDistance { get; set; }

        public bool IsPoint { get; set; }

        public ShipType Type { get; set; }

        public float Speed { get; set; }

        public int Dx { get; set; }

        public int Dy { get; set; }

        public string CompareTo(object obj)
        {
            string result;
            Ship ship = (Ship)obj;
            if (this.Type == ship.Type && ship.IsPoint && this.IsPoint)
            {
                result = "This ships are equals";
            }
            else
            {
                result = "This ships are not equals";
            }

            return result;
        }

        public string Move()
        {
            return "This ship is move with speed =" + this.Speed +" km/h";
        }
    }
}