using SeaBattle.Interfaces;

namespace SeaBattle
{
    public class AuxiliaryShip : Ship, IAbstractAuxiliaryShip
    {
        public string Repair()
        {
            return "Repair by Auxiliary with range" + this.Range;
        }
    }
}
