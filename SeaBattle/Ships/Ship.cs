using System.Text;

namespace SeaBattle
{
    public abstract class Ship
    {
        public string[] ar;
        public string[] AddToIndexArr(int size, int value)
        {
            if(ar == null)
            {
                ar = new string[size+1];
            }
            ar.SetValue(value.ToString(), size);
            return ar;
        }

        public string this[int q]
        {
            get { return ar[q]; }
            set { ar[q] = value; }
        }

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
            result = this.Type == ship.Type && 
                     this.Speed == ship.Speed &&
                     ship.IsPoint && this.IsPoint
                     ? "This ships are equals"
                     : "This ships are not equals";

            return result;
        }

        public StringBuilder Move()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("This ship is move with speed = {0} km/h in directions dx = {1}, dy ={2}",
                                       this.Speed,
                                       this.Dx,
                                       this.Dy);
            return stringBuilder;
        }
    }
}