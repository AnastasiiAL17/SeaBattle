namespace SeaBattle
{
    class AuxiliaryShip : Ship, IRepairable
    {
        public string Repair()
        {
            return "Repair by Auxiliary with range" + Range;
        }
    }
}
