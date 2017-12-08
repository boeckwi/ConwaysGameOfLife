using System;
using Conway.Contracts;
using Conway.Tests;
using Conway.Values;

namespace Conway.Lib
{
    public class EvolvesWorld : IEvolvesWorld
    {
        readonly IFindsLivingCells finds_living_cells;
        readonly IFindsSpacesAroundLivingCells finds_spaces_around_living_cells;
        readonly IEvolvesCells evolves_cells;

        public EvolvesWorld(IFindsLivingCells findsLivingCells, IFindsSpacesAroundLivingCells findsSpacesAroundLivingCells, IEvolvesCells evolvesCells )
        {
            finds_living_cells = findsLivingCells;
            finds_spaces_around_living_cells = findsSpacesAroundLivingCells;
            evolves_cells = evolvesCells;
        }

        public World Evolve(World world)
        {
            return evolves_cells.EvolveCells(world, finds_living_cells.FindLivingCellsIn(world), finds_spaces_around_living_cells.FindSpacesIn(world));
        }
    }
}
