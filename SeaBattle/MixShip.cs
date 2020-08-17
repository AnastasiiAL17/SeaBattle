namespace SeaBattle
{
    class MixShip : Ship, IRepairable, IShootable
    {
        void IRepairable.Repair(int range)
        {
            throw new System.NotImplementedException();
        }

        void IShootable.Shoot(int range)
        {
            throw new System.NotImplementedException();
        }
    }
}
