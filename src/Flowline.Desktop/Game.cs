namespace Flowline.Desktop;

using System.Numerics;
using Flowline.Core;
using Raylib_cs;

public class Game
{
    private readonly Simulation _sim = new(new Grid(35, 20));
    private const int TileSize = 48;
    private readonly Vector2 _gridOrigin = new(100, 60);

    public void Update()
    {
        // Update all tiles

        var mouse = Raylib.GetMousePosition();
        var (cx, cy) = ScreenToCell(mouse);

        if (Raylib.IsMouseButtonPressed(MouseButton.Left))
        {
            if (!_sim.Grid.TryPlace(cx, cy, new Source { Facing = Direction.Right }))
            {
                _sim.Grid.Remove(cx, cy);
            }
        }
    }

    public void Draw()
    {
        // Draw all tiles
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.DarkGray);

        DrawGridLines();
        DrawTiles();

        Raylib.EndDrawing();
    }

    public void DrawTiles()
    {
        for (int y = 0; y < _sim.Grid.Height; y++)
        {
            for (int x = 0; x < _sim.Grid.Width; x++)
            {
                Tile? tile = _sim.Grid.Get(x, y);
                if (tile == null)
                    continue;

                int px = (int)_gridOrigin.X + x * TileSize;
                int py = (int)_gridOrigin.Y + y * TileSize;

                Color color = tile switch
                {
                    Belt => Color.Yellow,
                    Source => Color.Green,

                    _ => Color.Magenta,
                };

                Raylib.DrawRectangle(px, py, TileSize, TileSize, color);
            }
        }
    }

    private void DrawGridLines()
    {
        for (int y = 0; y < _sim.Grid.Height; y++)
        {
            for (int x = 0; x < _sim.Grid.Width; x++)
            {
                int px = (int)_gridOrigin.X + x * TileSize;
                int py = (int)_gridOrigin.Y + y * TileSize;
                Raylib.DrawRectangleLines(px, py, TileSize, TileSize, Color.Gray);
            }
        }
    }

    private (int x, int y) ScreenToCell(Vector2 screen)
    {
        float localX = screen.X - _gridOrigin.X;
        float localY = screen.Y - _gridOrigin.Y;

        int cellX = (int)MathF.Floor(localX / TileSize);
        int cellY = (int)MathF.Floor(localY / TileSize);

        return (cellX, cellY);
    }
}
