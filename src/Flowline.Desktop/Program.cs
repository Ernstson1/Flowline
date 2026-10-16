using Raylib_cs;

Raylib.InitWindow(800, 600, "Flowline");

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.DarkGray);
    Raylib.DrawText("Flowline", 320, 280, 32, Color.White);
    Raylib.EndDrawing();
}

Raylib.CloseWindow();