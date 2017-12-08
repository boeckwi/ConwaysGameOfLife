using System.Collections.Generic;
using System.Linq;

public class ConwayLife
{
    public static int[,] GetGeneration(int[,] cells, int generation)
    {
        if (generation == 0)
            return cells;

        return GetGeneration(new ConwayLife().Evolve(cells), generation - 1);
    }

    readonly IConvertsWorld converts_world;
    readonly IEvolvesWorld evolves_world;

    public ConwayLife() : this(new ConvertsWorld(), new EvolvesWorld()) { }

    public ConwayLife(IConvertsWorld converts_world, IEvolvesWorld evolves_world)
    {
        this.converts_world = converts_world;
        this.evolves_world = evolves_world;
    }

    public int[,] Evolve(int[,] cells)
    {
        var world = converts_world.FromMatrix(cells);
        var evolved_world = evolves_world.Evolve(world);
        return converts_world.ToMatrix(evolved_world);
    }
}

public class World
{
    public HashSet<Point> Cells { get; private set; }

    public World(IEnumerable<Point> cells)
    {
        Cells = new HashSet<Point>(cells);
    }

    public World(params Point[] cells)
    {
        Cells = new HashSet<Point>(cells);
    }

    public int Left   => Cells.Min(x => x.X);
    public int Right  => Cells.Max(x => x.X);
    public int Top    => Cells.Min(x => x.Y);
    public int Bottom => Cells.Max(x => x.Y);
    public int Width  => Right  - Left + 1;
    public int Height => Bottom - Top  + 1;
}

public struct Point
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Point(int x, int y) { X = x; Y = y; }

    public IEnumerable<Point> Adjacents()
    {
        yield return Move(-1, -1);
        yield return Move(-1, 0);
        yield return Move(-1, +1);

        yield return Move(0, -1);
        yield return Move(0, +1);

        yield return Move(+1, -1);
        yield return Move(+1, 0);
        yield return Move(+1, +1);
    }

    Point Move(int dx, int dy) => new Point(X + dx, Y + dy);

    public override string ToString() => $"{X}:{Y}";
}

public interface IConvertsWorld
{
    World FromMatrix(int[,] matrix);
    int[,] ToMatrix(World world);
}

public class ConvertsWorld : IConvertsWorld
{
    int[,] matrix;
    World world;

    public World FromMatrix(int[,] cells)
    {
        matrix = cells;
        MatrixToWorld();
        return world;
    }

    void MatrixToWorld()
    {
        world = new World(PointsInMatrix());
    }

    IEnumerable<Point> PointsInMatrix()
    {
        for (int x = 0; x < matrix_width; x++)
            for (int y = 0; y < matrix_height; y++)
                if (matrix[x, y] == 1)
                    yield return new Point(x, y);
    }

    int matrix_width => matrix.GetLength(0);
    int matrix_height => matrix.GetLength(1);

    public int[,] ToMatrix(World world)
    {
        this.world = world;
        WorldToMatrix();
        return matrix;
    }

    void WorldToMatrix()
    {
        InitMatrix();

        foreach (var c in world.Cells)
            SetPointInMatrix(c.X, c.Y);
    }

    void InitMatrix()
    {
        matrix = new int[world.Width, world.Height];
    }

    void SetPointInMatrix(int x, int y)
    {
        matrix[x - world.Left, y - world.Top] = 1;
    }
}

public interface IEvolvesWorld
{
    World Evolve(World world);
}

public class EvolvesWorld : IEvolvesWorld
{
    IAnalysesCells analyses_cell;
    Point[] cells;

    public EvolvesWorld() : this(new AnalysesCells()) { }

    public EvolvesWorld(IAnalysesCells analyses_cell)
    {
        this.analyses_cell = analyses_cell;
    }

    public World Evolve(World world)
    {
        cells = world.Cells.ToArray();

        return new World(cells.Except(ToRemove).Concat(ToCreate));
    }

    Point[] ToRemove => analyses_cell.FindCellsToRemove(cells);
    Point[] ToCreate => analyses_cell.FindCellsToCreate(cells);
}

public interface IAnalysesCells
{
    Point[] FindCellsToRemove(Point[] cells);
    Point[] FindCellsToCreate(Point[] cells);
}

public class AnalysesCells : IAnalysesCells
{
    Point[] cells;

    public Point[] FindCellsToCreate(Point[] cells)
    {
        var surrounding_points = cells.SelectMany(c => c.Adjacents()).Where(x => !cells.Contains(x));
        return surrounding_points.GroupBy(x => x).Where(AreThree).Select(g => g.Key).ToArray();
    }

    static bool AreThree(IEnumerable<Point> points)
    {
        return points.Count() == 3;
    }

    public Point[] FindCellsToRemove(Point[] cells)
    {
        this.cells = cells;
        return cells.Where(ShouldBeRemoved).ToArray();
    }

    bool ShouldBeRemoved(Point cell)
    {
        var n = NeighboursOf(cell);
        return n < 2 || n > 3;
    }

    int NeighboursOf(Point cell)
    {
        return cell.Adjacents().Intersect(cells).Count();
    }
}