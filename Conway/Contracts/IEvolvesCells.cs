using Conway.Values;

namespace Conway.Contracts
{
    public interface IEvolvesCells
    {
        World EvolveCells(World world, Cell[] spaces, Cell[] living_cells);
    }
}