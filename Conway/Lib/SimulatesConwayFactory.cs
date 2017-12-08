using System;
using Conway.Values;

namespace Conway.Lib
{
    public class SimulatesConwayFactory
    {
        public SimulatesConway Create(Action<World> outputs_world)
        {
            return new SimulatesConway(new CreatesWorldFromString(), EvolvesWorld(), new OutputsWorld(outputs_world));
        }

        static EvolvesWorld EvolvesWorld()
        {
            return new EvolvesWorld(new FindsLivingCells(), new FindsSpacesAroundLivingCells(), new EvolvesCells());
        }
    }
}