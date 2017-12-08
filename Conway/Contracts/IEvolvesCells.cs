using Conway.Values;

namespace Conway.Contracts
{
    public interface IEvolvesCells
    {
        World EvolveCells(World world, Cell[] living_cells, Cell[] cells);
    }
}