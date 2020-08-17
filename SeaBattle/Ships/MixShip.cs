namespace SeaBattle
{
    using System;
    class MixShip : Ship, IRepairable, IShootable
    {
        public void Repair(int range)
        {
            Console.WriteLine("Repair by MixShip");
        }

        public void Shoot(int range)
        {
            Console.WriteLine("Shoot by MixShip");
        }
    }
}
