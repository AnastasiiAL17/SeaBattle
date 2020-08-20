namespace SeaBattle
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            _ = (AuxiliaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.auxiliary);
            _ = (MilitaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.military);
            MixShip mixShip = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            MixShip mixShip1 = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            Console.WriteLine(playingField.GetAllShips());
            var a = mixShip == mixShip1;
            var b = mixShip != mixShip1;
        }
    }
}
