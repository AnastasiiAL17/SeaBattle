namespace SeaBattle
{
    using System.Text;

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

        public StringBuilder Move()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("This ship is move with speed = {0} km/h in directions dx = {1}, dy ={2}",
                                       this.Speed,
                                       this.Dx,
                                       this.Dy);
            return stringBuilder;
        }

        public static string operator >=(Ship a, Ship b)
        {
            return "this operation is not support";
        }

        public static string operator <=(Ship a, Ship b)
        {
            return "this operation is not support";
        }

        public static string operator >(Ship a, Ship b)
        {
            return "this operation is not support";
        }

        public static string operator <(Ship a, Ship b)
        {
            return "this operation is not support";
        }

        private static bool IsEqualsShips(Ship a, Ship b)
        {
            bool res;
            res = a.Type == b.Type &&
                  a.Speed == b.Speed &&
                  b.IsPoint && a.IsPoint;
            return res;
        }
        public static bool operator ==(Ship a, Ship b)
        {
            return IsEqualsShips(a,b);
        }

        public static bool operator !=(Ship a, Ship b)
        {
            return !IsEqualsShips(a, b);
        }
    }
}