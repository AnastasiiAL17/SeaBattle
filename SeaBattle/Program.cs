namespace SeaBattle
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            _ = (AuxiliaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.auxiliary);
            _ = (MilitaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.military);
            MixShip mixShip  = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            MixShip mixShip1 = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            mixShip1.CompareTo(mixShip);
            Console.WriteLine(playingField.GetAllShips());
        }
    }
}
