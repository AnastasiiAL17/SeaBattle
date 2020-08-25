namespace SeaBattle.Interfaces
{
    public interface IAbstractShip
    {

        IAbstractAuxiliaryShip CreateAuxiliaryShip();
        IAbstractMilitaryShip CreateMilitaryShip();
        IAbstractMixShip CreateMixShip();
    }
}
