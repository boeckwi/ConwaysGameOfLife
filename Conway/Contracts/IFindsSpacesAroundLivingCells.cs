using Conway.Values;

namespace Conway.Contracts
{
    public interface IFindsSpacesAroundLivingCells
    {
        Cell[] FindSpacesIn(World world);
    }
}