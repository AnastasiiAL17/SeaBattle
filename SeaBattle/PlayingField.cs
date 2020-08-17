namespace SeaBattle
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;

    public class PlayingField
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Ship> Ships { get; set; }

        public PlayingField()
        {
            Ships = new List<Ship>();
        }
        public Ship AddShip(Point startPoint, ShipType type)
        {
            Ship ship = new MixShip();
            switch (type)
            {
                case ShipType.auxiliary:
                    ship = new AuxiliaryShip
                    {
                        Type = ShipType.auxiliary
                    };
                    break;
                case ShipType.military:
                    ship = new MilitaryShip
                    {
                        Type = ShipType.military
                    };
                    break;
                case ShipType.mix:
                    ship = new MixShip
                    {
                        Type = ShipType.mix
                    };
                    break;
            }
            ship.Coordinates = startPoint;
            Random random = new Random();
            ship.Dx = random.Next(-1, 1);
            ship.Dy = random.Next(-1, 1);
            ship.Quadrant = this.GetQuadrant(ship.Coordinates);
            ship.Lenght = random.Next(1, 5);
            ship.IsPoint = ship.Lenght == 1;
            ship.Range = random.Next(1, 5);
            ship.Speed = random.Next(1, 5);
            ship.Index = this.GenerateIndex(ship.Quadrant, ship.Coordinates);
            Ships.Add(ship);
           
            return ship;
        }

        private void CheckEmptyPlace(Point startPoint, int lentgth)
        {

        }

        public void SelectShip(string parameter)
        {
            Ship selected = Ships.Find(i => i.Index.Equals(parameter));
        }

        public StringBuilder GetAllShips()
        {
            StringBuilder res = new StringBuilder();
            for(int i = 0; i < Ships.Count; i++)
            {
                res.AppendFormat(string.Format("Ship #{0} \n"+
                                               "========================== \n" +
                                               "Quadrant: {1} \n" +
                                               "[x;y] = [{2};{3}] \n" +
                                               "========================== \n",
                                 Ships[i].Index,
                                 Ships[i].Quadrant,
                                 Ships[i].Coordinates.X,
                                 Ships[i].Coordinates.Y));
            }
            return res;
        }

        public void SortByCenterDistance()
        {

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
