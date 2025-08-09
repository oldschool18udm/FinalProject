using System;

namespace Snake;

public class ScoreBoard
{
    private static int sizex = 15;
    private static int sizey = 7;
    private static int startx = Config.BOARDWIDTH + 5;
    private static int starty = 0;
    public static Walls walls = new Walls();

    public void DrawGameState()
    {
        Console.SetCursorPosition(startx, 0);
        walls.Draw(startx, starty, startx + sizex, sizey + starty);
        Console.SetCursorPosition(startx + 2, starty + 1);
        Console.Write($"Score: {Program.playerScore}");

        Console.SetCursorPosition(startx + 2, starty + 2);
        Console.Write($"Lives: {Program.lives}");

        Console.SetCursorPosition(startx + 2, starty + 3);
        Console.Write($"Record: {Program.bestScore}");
    }
}