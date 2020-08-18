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
                case ShipType.auxiliary:
                    ship = new AuxiliaryShip
                    {
                        Type = ShipType.auxiliary
                    };
                    AuxiliaryShip auxiliaryShip = (AuxiliaryShip)ship;
                    auxiliaryShip.Repair();
                    break;
                case ShipType.military:
                    ship = new MilitaryShip
                    {
                        Type = ShipType.military
                    };
                    MilitaryShip militaryShip = (MilitaryShip)ship;
                    militaryShip.Shoot();
                    break;
                case ShipType.mix:
                    ship = new MixShip
                    {
                        Type = ShipType.mix
                    };
                    MixShip mixShip = (MixShip)ship;
                    mixShip.Repair();
                    mixShip.Shoot();
                    break;
            }

            this.InitializeShip(ref ship, startPoint);
            this.Ships.Add(startPoint, ship);
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

        public StringBuilder SelectShip(string parameter)
        {
            StringBuilder result = new StringBuilder();
            Ship selected = this.Ships.Values.FirstOrDefault(i => i.Index.Equals(parameter));
            if (selected != null)
            {
                result.Append(string.Format("Selected ship #{0} \n", selected.Index));
            }
            else
            {
                result.Append("Ship was not selected");
            }

            return result;
        }

        public StringBuilder GetAllShips()
        {
            this.Ships = this.SortByCenterDistance();
            StringBuilder res = new StringBuilder();
            foreach (KeyValuePair<Point, Ship> keyValuePairs in this.Ships)
            {
                res.AppendFormat(string.Format("Ship #{0} \n" +
                                               "-------------------------- \n" +
                                               "[x; y] = [{1};{2}] \n" +
                                               "Length = {3} \n" +
                                               "Type: {4} \n" +
                                               "========================== \n",
                                 keyValuePairs.Value.Index,
                                 keyValuePairs.Key.X,
                                 keyValuePairs.Key.Y,
                                 keyValuePairs.Value.Lenght,
                                 keyValuePairs.Value.Type));
            }

            return res;
        }

        public Dictionary<Point, Ship> SortByCenterDistance()
        {
            return this.Ships.OrderBy(obj => obj.Value.CenterDistance).ToDictionary(obj => obj.Key, obj => obj.Value);
        }

        public string GenerateIndex(byte quadrant, Point shipPoint)
        {
            return string.Concat(quadrant, Math.Abs(shipPoint.X), Math.Abs(shipPoint.Y));
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
            ship.Lenght = random.Next(1, 5);
            ship.IsPoint = ship.Lenght == 1;
            ship.Speed = random.Next(1, 5);
            ship.Index = this.GenerateIndex(this.GetQuadrant(coordinates), coordinates);
            ship.CenterDistance = Math.Sqrt(Math.Pow(coordinates.X - 0, 2) + Math.Pow(coordinates.Y - 0, 2));
        }
    }
}
