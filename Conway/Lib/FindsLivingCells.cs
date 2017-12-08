using Conway.Contracts;
using Conway.Values;
using System.Linq;
using System;

namespace Conway.Lib
{
    public class FindsLivingCells : IFindsLivingCells
    {
        public Cell[] FindLivingCellsIn(Location[] cells)
        {
            return cells.Select(l => new Cell(l, l.CountNeighbours(cells))).ToArray();
        }
    }
}