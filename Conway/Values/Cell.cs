namespace Conway.Values
{
    public class Cell
    {
        public string Name { get; private set; }
        public int LivingNeighbours { get; private set; }

        public Cell(string name, int living_neighbours)
        {
            Name = name;
            LivingNeighbours = living_neighbours;
        }
    }
}