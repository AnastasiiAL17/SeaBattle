namespace SeaBattle
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;

    public class PlayingField
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<Point, Ship> Ships { get; set; }

        public PlayingField()
        {
            Ships = new Dictionary<Point, Ship>();
        }
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
                    AuxiliaryShip aShip = (AuxiliaryShip)ship;
                    aShip.Repair(ship.Range);
                    break;
                case ShipType.military:
                    ship = new MilitaryShip
                    {
                        Type = ShipType.military
                    };
                    MilitaryShip mShip = (MilitaryShip)ship;
                    mShip.Shoot(ship.Range);
                    break;
                case ShipType.mix:
                    ship = new MixShip
                    {
                        Type = ShipType.mix
                    };
                    MixShip mixShip = (MixShip)ship;
                    mixShip.Repair(ship.Range);
                    mixShip.Shoot(ship.Range);
                    break;
            }
        
            InitializeShip(ref ship, startPoint);
            Ships.Add(startPoint, ship);
            return ship;
        }

        private void InitializeShip(ref Ship ship, Point Coordinates)
        {
            Random random = new Random();
            ship.Dx = random.Next(-1, 1);
            ship.Dy = random.Next(-1, 1);
            ship.Quadrant = this.GetQuadrant(Coordinates);
            ship.Lenght = random.Next(1, 5);
            ship.IsPoint = ship.Lenght == 1;
            ship.Speed = random.Next(1, 5);
            ship.Index = this.GenerateIndex(ship.Quadrant, Coordinates);
            ship.CenterDistance = (Math.Sqrt(Math.Pow(Coordinates.X - 0, 2) + Math.Pow(Coordinates.Y - 0, 2)));
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

       

        public void SelectShip(string parameter)
        {
            StringBuilder result = new StringBuilder();
            Ship selected = Ships.Values.FirstOrDefault(i => i.Index.Equals(parameter));
            if(selected != null)
            {
                result.Append(string.Format("Selected ship #{0} \n",
                              selected.Index));
            }
            else
            {
                result.Append("Ship was not selected");
            }
            Console.WriteLine(result);
        }


        public StringBuilder GetAllShips()
        {
     //       Ships = SortByCenterDistance();
            StringBuilder res = new StringBuilder();
            foreach(KeyValuePair<Point, Ship> keyValuePairs in Ships)
   
            {
                res.AppendFormat(string.Format("Ship #{0} [{1};{2}] \n"+
                                               "-------------------------- \n" +
                                               "Quadrant: {3} \n" +
                                               "Length = {4} \n"+
                                               "Type: {5} \n" +
                                               "========================== \n",
                                 keyValuePairs.Value.Index,
                                 keyValuePairs.Key.X,
                                 keyValuePairs.Key.Y,
                                 keyValuePairs.Value.Quadrant,
                                 keyValuePairs.Value.Lenght,
                                 keyValuePairs.Value.Type));
            }
            return res;
        }

        public Dictionary<Point, Ship> SortByCenterDistance()
        {
            return (Dictionary<Point, Ship>)Ships.OrderBy(i => i.Value.CenterDistance);
        }

        private byte GetQuadrant(Point shipPoint)
        {
            if(shipPoint.X * shipPoint.Y > 0)
            {
                return (shipPoint.X > 0 && shipPoint.Y > 0 )? (byte)2 : (byte)3;
            }
            else
            {
                return shipPoint.X > 0 && shipPoint.Y < 0 ? (byte)4 : (byte)1;
            }
        }

        public string GenerateIndex(byte quadrant, Point shipPoint)
        {
            return string.Concat(quadrant, Math.Abs(shipPoint.X), Math.Abs(shipPoint.Y));
        }
    }
}
