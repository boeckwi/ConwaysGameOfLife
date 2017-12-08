using Conway.Contracts;
using Conway.Values;
using System.Linq;

namespace Conway.Lib
{
    public class FindsSpacesAroundLivingCells : IFindsSpacesAroundLivingCells
    {
        public Cell[] FindSpacesAround(Location[] living_cells)
        {
            var locations = living_cells.SelectMany(c => c.Surrounding()).Distinct().ToArray();

            return locations.Except(living_cells).Select(l => new Cell(l, l.CountNeighbours(living_cells))).ToArray();
        }

    }
}