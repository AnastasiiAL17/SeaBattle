namespace SeaBattle
{
    using System;
    class MixShip : Ship, IRepairable, IShootable
    {
        public void Repair()
        {
            Console.WriteLine("Repair by MixShip");
        }

        public void Shoot()
        {
            Console.WriteLine("Shoot by MixShip");
        }
    }
}
