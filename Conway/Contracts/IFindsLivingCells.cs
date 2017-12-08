using Conway.Values;

namespace Conway.Contracts
{
    public interface IFindsLivingCells
    {
        Cell[] FindLivingCellsIn(Location[] cells);
    }
}