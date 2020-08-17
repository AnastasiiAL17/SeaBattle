namespace SeaBattle
{
    class AuxiliaryShip : Ship, IRepairable
    {
        void IRepairable.Repair(int range)
        {
            throw new System.NotImplementedException();
        }
    }
}
