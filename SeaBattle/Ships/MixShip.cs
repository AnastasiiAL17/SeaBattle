namespace SeaBattle
{
    public class MixShip : Ship, IRepairable, IShootable
    {
        public string Repair()
        {
            return "Repair by MixShip" + this.Range;
        }

        public string Shoot()
        {
            return "Shoot by MixShip" + this.Range;
        }
    }
}
