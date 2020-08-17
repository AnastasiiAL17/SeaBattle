using System;
using System.Drawing;

namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            
            Ship ship = playingField.AddShip(InitNewPoint(), ShipType.auxiliary);
            playingField.AddShip(InitNewPoint(), ShipType.military);
            Console.WriteLine(playingField.GetAllShips());
        }

        private static Point InitNewPoint()
        {
            Random random = new Random();
            Point point = new Point
            {
                X = random.Next(-100, 100),
                Y = random.Next(-100, 100)
            };
            return point;
        }
    }
}
