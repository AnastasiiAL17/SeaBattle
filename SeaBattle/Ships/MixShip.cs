namespace SeaBattle
{
    class MixShip : Ship, IRepairable, IShootable
    {
        public string Repair()
        {
           return "Repair by MixShip" + Range;
        }

        public string Shoot()
        {
            return "Shoot by MixShip" + Range;
        }
    }
}
