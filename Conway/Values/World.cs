using System.Linq;

namespace Conway.Values
{
    public struct World
    {
        public Location[] LivingCells { get; set; }

        public override string ToString()
        {
            if (LivingCells == null) return "";
            return string.Join("\r\n", LivingCells.Select(x => x.Name()));
        }
    }
}