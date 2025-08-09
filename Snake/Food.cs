namespace Snake;
using System;

public class Food
{
    private static Random rnd = new Random();
    private static int x = rnd.Next(1, Program.width - 1);
    private static int y = rnd.Next(1, Program.height - 1);
    private static string foodskin = Config.FOODBODY;
    public static Point apple = new Point(x, y, foodskin);
    private int color = Config.FOODCOLOR;

    public void Spawn()
    {
        apple.x = rnd.Next(1, Program.width - 1);
        apple.y = rnd.Next(1, Program.height - 1);
    }

    public void Draw()
    {
        Console.ForegroundColor = (ConsoleColor)color;
        apple.Draw();
        Console.ResetColor();
    }
}