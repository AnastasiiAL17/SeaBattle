namespace SeaBattle
{
    using System;

    public class Program
    {
        private static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            _ = (AuxiliaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.Auxiliary);
            _ = (MilitaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.Military);
            MixShip mixShip = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.Mix);
            MixShip mixShip1 = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.Mix);
            Console.WriteLine(playingField.GetAllShips());
            var t = mixShip.Equals(mixShip1);
            var f = mixShip.Equals(mixShip1);
            var a = mixShip == mixShip1;
            var b = mixShip != mixShip1;
        }
    }
}
