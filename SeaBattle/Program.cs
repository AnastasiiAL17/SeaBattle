namespace SeaBattle
{
    using System;
    using System.Drawing;

    class Program
    {
        static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            
            playingField.AddShip(InitNewPoint(), ShipType.auxiliary);
            playingField.AddShip(InitNewPoint(), ShipType.military);
            playingField.AddShip(InitNewPoint(), ShipType.mix);
            playingField.AddShip(InitNewPoint(), ShipType.mix);
            Console.WriteLine(playingField.GetAllShips());
            playingField.SortByCenterDistance();
        }

        private static Point InitNewPoint()
        {
            Random random = new Random();
            Point point = new Point
            {
                X = random.Next(-10, 10),
                Y = random.Next(-10, 10)
            };
            return point;
        }
    }
}
