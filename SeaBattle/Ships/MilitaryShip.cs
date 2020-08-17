namespace SeaBattle
{
    class MilitaryShip : Ship, IShootable
    {
        void IShootable.Shoot(int range)
        {
            throw new System.NotImplementedException();
        }
    }
}
