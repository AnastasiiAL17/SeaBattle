using SeaBattle.Interfaces;

namespace SeaBattle
{
    public class MilitaryShip : Ship, IAbstractMilitaryShip
    {
        public string Shoot()
        {
            return "Shoot by Military ship" + this.Range;
        }
    }
}
