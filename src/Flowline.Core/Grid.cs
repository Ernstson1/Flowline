namespace Flowline.Core;

public class Grid
{
    private readonly Tile?[,] _tiles;

    public int Width { get; }
    public int Height { get; }

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        _tiles = new Tile?[width, height];
    }

    public bool TryPlace(int x, int y, Tile tile)
    {
        if (!IsEmpty(x, y))
            return false;

        _tiles[x, y] = tile;
        return true;
    }

    public void Remove(int x, int y)
    {
        if (!IsInBounds(x, y))
            return;
        _tiles[x, y] = null;
    }

    public Tile? Get(int x, int y)
    {
        if (!IsInBounds(x, y))
            return null;
        return _tiles[x, y];
    }

    private bool IsInBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }

    private bool IsEmpty(int x, int y)
    {
        return IsInBounds(x, y) && _tiles[x, y] == null;
    }
}
