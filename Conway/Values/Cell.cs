namespace Conway.Values
{
    public class Cell
    {
        public int LivingNeighbours { get; private set; }
        public Location Location { get; private set; }

        public Cell(Location location, int living_neighbours)
        {
            Location = location;
            LivingNeighbours = living_neighbours;
        }

        public override string ToString()
        {
            return Location.Name() + ":" + LivingNeighbours;
        }
    }
}