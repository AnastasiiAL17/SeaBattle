namespace SeaBattle
{
    using System;
    class MilitaryShip : Ship, IShootable
    {
        public void Shoot(int range)
        {
            Console.WriteLine("Shoot by Military ship");
        }
    }
}
