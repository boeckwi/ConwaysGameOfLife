using Conway.Values;

namespace Conway.Contracts
{
    public interface IFindsSpacesAroundLivingCells
    {
        Cell[] FindSpacesAround(Location[] living_cells);
    }
}