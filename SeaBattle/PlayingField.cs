namespace SeaBattle
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class PlayingField
    {
        public PlayingField()
        {
            this.Ships = new Dictionary<Point, Ship>();
        }

        public Dictionary<Point, Ship> Ships { get; set; }

        public Ship AddShip(Point startPoint, ShipType type)
        {
            Random random = new Random();
            Ship ship = new MixShip
            {
                Range = random.Next(1, 5)
            };
            switch (type)
            {
                case ShipType.Auxiliary:
                    ship = new AuxiliaryShip
                    {
                        Type = ShipType.Auxiliary
                    };
                    AuxiliaryShip auxiliaryShip = (AuxiliaryShip)ship;
                    auxiliaryShip.Repair();
                    break;
                case ShipType.Military:
                    ship = new MilitaryShip
                    {
                        Type = ShipType.Military
                    };
                    MilitaryShip militaryShip = (MilitaryShip)ship;
                    militaryShip.Shoot();
                    break;
                case ShipType.Mix:
                    ship = new MixShip
                    {
                        Type = ShipType.Mix
                    };
                    MixShip mixShip = (MixShip)ship;
                    mixShip.Repair();
                    mixShip.Shoot();
                    break;
            }

            this.InitializeShip(ref ship, startPoint);
            this.Ships.Add(startPoint, ship);
            ship.AddToIndexArr(this.Ships.Count,
                               this.GenerateIndex(this.GetQuadrant(startPoint), startPoint));
            ship.Move();
            return ship;
        }

        public Point InitNewPoint()
        {
            Random random = new Random();
            Point point = new Point
            {
                X = random.Next(-10, 10),
                Y = random.Next(-10, 10)
            };
            return point;
        }

        public StringBuilder GetAllShips()
        {
            this.Ships = this.SortByCenterDistance();
            StringBuilder res = new StringBuilder();
            foreach (KeyValuePair<Point, Ship> keyValuePairs in this.Ships)
            {
                res.AppendFormat(string.Format("Ship \n" +
                                               "-------------------------- \n" +
                                               "[x; y] = [{0};{1}] \n" +
                                               "Length = {2} \n" +
                                               "Type: {3} \n" +
                                               "========================== \n",
                                 keyValuePairs.Key.X,
                                 keyValuePairs.Key.Y,
                                 keyValuePairs.Value.Length,
                                 keyValuePairs.Value.Type));
            }

            return res;
        }

        private Dictionary<Point, Ship> SortByCenterDistance()
        {
            return this.Ships.OrderBy(obj => obj.Value.CenterDistance).ToDictionary(obj => obj.Key, obj => obj.Value);
        }

        private int GenerateIndex(byte quadrant, Point shipPoint)
        {
            return Convert.ToInt32(string.Concat(quadrant, Math.Abs(shipPoint.X), Math.Abs(shipPoint.Y)));
        }

        private byte GetQuadrant(Point shipPoint)
        {
            if (shipPoint.X * shipPoint.Y > 0)
            {
                return (shipPoint.X > 0 && shipPoint.Y > 0) ? (byte)2 : (byte)3;
            }
            else
            {
                return shipPoint.X > 0 && shipPoint.Y < 0 ? (byte)4 : (byte)1;
            }
        }

        private void InitializeShip(ref Ship ship, Point coordinates)
        {
            Random random = new Random();
            ship.Dx = random.Next(-1, 1);
            ship.Dy = random.Next(-1, 1);
            ship.Length = random.Next(1, 5);
            ship.IsPoint = ship.Length == 1;
            ship.Speed = random.Next(1, 5);
            ship.CenterDistance = Math.Sqrt(Math.Pow(coordinates.X - 0, 2) + Math.Pow(coordinates.Y - 0, 2));
        }
    }
}
