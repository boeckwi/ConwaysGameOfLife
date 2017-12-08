using System;
using System.Collections.Generic;
using System.Linq;

namespace Conway.Values
{
    public struct Location
    {
        const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public int X { get; private set; }
        public int Y { get; private set; }

        public Location(string excel_notation)
        {
            X = Alphabet.IndexOf(excel_notation[0]);
            Y = int.Parse(excel_notation.Substring(1)) - 1;
        }

        public IEnumerable<Location> Surrounding()
        {
            yield return Move(-1, -1);
            yield return Move(-1,  0);
            yield return Move(-1, +1);
            yield return Move( 0, -1);

            yield return Move( 0, +1);
            yield return Move(+1, -1);
            yield return Move(+1,  0);
            yield return Move(+1, +1);
        }

        Location Move(int dx, int dy)
        {
            return new Location(X + dx, Y + dy);
        }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public string Name()
        {
            if (X < 0)
                return "-" + Alphabet[-X] + "" + (Y + 1);

            return Alphabet[X] + "" + (Y + 1);
        }

        public override string ToString()
        {
            return Name();
        }

        public int CountNeighbours(Location[] living_cells)
        {
            return living_cells.Intersect(Surrounding()).Count();
        }
    }
}