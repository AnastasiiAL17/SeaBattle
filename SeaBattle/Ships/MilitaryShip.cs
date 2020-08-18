namespace SeaBattle
{
    class MilitaryShip : Ship, IShootable
    {
        public string Shoot()
        {
            return "Shoot by Military ship"+ Range;
        }
    }
}
