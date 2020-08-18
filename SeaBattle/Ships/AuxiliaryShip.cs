namespace SeaBattle
{
    public class AuxiliaryShip : Ship, IRepairable
    {
        public string Repair()
        {
            return "Repair by Auxiliary with range" + this.Range;
        }
    }
}
