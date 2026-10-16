using Flowline.Desktop;
using Raylib_cs;

Raylib.InitWindow(1920, 1080, "Flowline");

var game = new Game();

while (!Raylib.WindowShouldClose())
{
    game.Update();
    game.Draw();
}

Raylib.CloseWindow();
