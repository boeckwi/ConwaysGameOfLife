using Conway.Values;

namespace Conway.Contracts
{
    public interface ICreatesWorldFromString
    {
        World CreateWorldFrom(string input);
    }
}