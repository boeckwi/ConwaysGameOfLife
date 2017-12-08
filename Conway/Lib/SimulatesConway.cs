using System;
using Conway.Contracts;

namespace Conway.Lib
{
    public class SimulatesConway
    {
        readonly ICreatesWorldFromString creates_world_from_string;
        readonly IEvolvesWorld evolves_world;
        readonly IOutputsWorld outputs_world;

        public SimulatesConway(ICreatesWorldFromString createsWorldFromString, IEvolvesWorld evolvesWorld, IOutputsWorld outputsWorld)
        {
            creates_world_from_string = createsWorldFromString;
            evolves_world = evolvesWorld;
            outputs_world = outputsWorld;
        }

        public void Simulate(string input, int generations)
        {
            var world = creates_world_from_string.CreateWorldFrom(input);
            outputs_world.Output(world);

            for (int i = 0; i < generations; i++)
            {
                world = evolves_world.Evolve(world);
                outputs_world.Output(world);
            }
        }
    }
}
