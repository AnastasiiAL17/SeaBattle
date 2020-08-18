namespace SeaBattle
{
    public class MilitaryShip : Ship, IShootable
    {
        public string Shoot()
        {
            return "Shoot by Military ship" + this.Range;
        }
    }
}
