namespace SeaBattle
{
    using System;
    class MilitaryShip : Ship, IShootable
    {
        public void Shoot()
        {
            Console.WriteLine("Shoot by Military ship");
        }
    }
}
