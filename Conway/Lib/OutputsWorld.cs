using System;
using Conway.Contracts;
using Conway.Values;

namespace Conway.Lib
{
    public class OutputsWorld : IOutputsWorld
    {
        readonly Action<World> outputs_world;

        public OutputsWorld(Action<World> outputsWorld)
        {
            outputs_world = outputsWorld;
        }

        public void Output(World world)
        {
            outputs_world(world);
        }
    }
}