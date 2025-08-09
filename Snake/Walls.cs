using System;
namespace Snake;

public class Walls
{
    private string _skin = Config.WALLSKIN;

    public void Draw(int left, int top, int right, int bottom)
    {
        DrawWallHor(left, right,top, _skin);
        DrawWallHor(left, right,bottom, _skin);
        DrawWallVert(left,top, bottom, _skin);
        DrawWallVert(right,top, bottom, _skin);
    }

    private void DrawWallHor(int left, int right, int y, string skin)
    {
        for (int i = left; i <=right; i++)
        {
            Point p = new Point(i, y, _skin);
            p.Draw();
        }
    }
    private void DrawWallVert(int x, int top, int bottom, string skin)
    {
        for (int i = top; i <= bottom; i++)
        {
            Point p = new Point(x, i, _skin);
            p.Draw();
        }
        
    }
}