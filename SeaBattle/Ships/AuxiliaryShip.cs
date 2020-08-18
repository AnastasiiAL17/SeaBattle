namespace SeaBattle
{
    using System;
    class AuxiliaryShip : Ship, IRepairable
    {
        public void Repair()
        {
            Console.WriteLine("Repair by Auxiliary ");
        }
    }
}
