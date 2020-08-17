namespace SeaBattle
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            
            playingField.AddShip(playingField.InitNewPoint(), ShipType.auxiliary);
            playingField.AddShip(playingField.InitNewPoint(), ShipType.military);
            playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            Console.WriteLine(playingField.GetAllShips());
            playingField.SortByCenterDistance();
        }
    }
}
