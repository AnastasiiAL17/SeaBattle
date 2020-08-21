namespace SeaBattle
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class Program
    {
        private static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            playingField.AddShip(playingField.InitNewPoint(), ShipType.Auxiliary);
            playingField.AddShip(playingField.InitNewPoint(), ShipType.Military);
            MixShip mixShip = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.Mix);
            MixShip mixShip1 = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.Mix);
            playingField.GetAllShips();
            foreach (KeyValuePair<Point, Ship> keyValuePairs in playingField.Ships)
            {
                Console.WriteLine("Ship [{0};{1}] \n" +
                                  "---------------- \n" +
                                  "Length {2}" , 
                                  keyValuePairs.Key.X, 
                                  keyValuePairs.Key.Y,
                                  keyValuePairs.Value.Length);
            }
            
            var t = mixShip.Equals(mixShip1);
            var f = mixShip.Equals(mixShip);
            var a = mixShip == mixShip1;
            var b = mixShip != mixShip1;
        }
    }
}
