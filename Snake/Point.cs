using System;
namespace Snake;

public class Point
{
    public int x = 10;
    public int y = 10;
    public string skin = "o";

    public Point(int x, int y, string skin)
    {
        this.x = x;
        this.y = y;
        this.skin = skin;
    }

    public void Draw()
    {
        DrawPoint(skin);
    }

    public void Clear()
    {
        DrawPoint(" ");
    }

    private void DrawPoint(string skin)
    {
        Console.SetCursorPosition(x, y);
        Console.Write(skin);
    }
}