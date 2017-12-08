using Conway.Values;

namespace Conway.Contracts
{
    public interface IFindsLivingCells
    {
        Cell[] FindLivingCellsIn(World world);
    }
}