namespace SeaBattle
{
    using System;
    class MixShip : Ship, IRepairable, IShootable
    {
        public string Repair()
        {
           return "Repair by MixShip";
        }

        public string Shoot()
        {
            return "Shoot by MixShip";
        }
    }
}
