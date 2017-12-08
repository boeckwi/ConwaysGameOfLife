using Conway.Values;

namespace Conway.Contracts
{
    public interface IEvolvesWorld
    {
        World Evolve(World world);
    }
}