namespace SeaBattle
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            PlayingField playingField = new PlayingField();
            
            AuxiliaryShip auxiliaryShip = (AuxiliaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.auxiliary);
            MilitaryShip militaryShip = (MilitaryShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.military);
            MixShip mixShip  = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            MixShip mixShip1 = (MixShip)playingField.AddShip(playingField.InitNewPoint(), ShipType.mix);
            mixShip1.CompareTo(mixShip);
            Console.WriteLine(playingField.GetAllShips());

            //Console.WriteLine("Do you want select ship? Input index:");
            //string index = Console.ReadLine();
            //playingField.SelectShip(index);
        }
    }
}
