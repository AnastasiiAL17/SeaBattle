namespace SeaBattle
{
    using System;
    class AuxiliaryShip : Ship, IRepairable
    {
        public void Repair(int range)
        {
            Console.WriteLine("Repair by Auxiliary ");
        }
    }
}
