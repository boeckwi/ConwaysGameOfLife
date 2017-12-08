using System;
using System.Linq;
using Conway.Contracts;
using Conway.Values;

namespace Conway.Lib
{
    public class EvolvesCells : IEvolvesCells
    {
        public World EvolveCells(World world, Cell[] living_cells, Cell[] spaces)
        {
            var newCells = spaces.Where(HasThreeNeighbours);
            var stayAlive = living_cells.Where(HasTwoOrThreeNeighbours);

            return new World
            {
                LivingCells = stayAlive.Concat(newCells).Select(LocationOf).ToArray(),
            };
        }

        bool HasThreeNeighbours(Cell c)
        {
            var n = c.LivingNeighbours;
            return n == 3;
        }

        bool HasTwoOrThreeNeighbours(Cell c)
        {
            var n = c.LivingNeighbours;
            return n == 2 || n == 3;
        }

        Location LocationOf(Cell c)
        {
            return c.Location;
        }
    }
}
