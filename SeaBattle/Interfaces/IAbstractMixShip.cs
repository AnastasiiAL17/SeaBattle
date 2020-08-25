namespace SeaBattle.Interfaces
{
    public interface IAbstractMixShip : IShootable, IRepairable
    {
        string Repair();
        string Shoot();
    }
}
