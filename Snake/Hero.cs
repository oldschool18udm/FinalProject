using System;
using System.Collections.Generic;

namespace Snake;

public class Hero
{
    int[] direction = new int[] { 1, 0 };
    private static string skinbody = Config.SNAKEBODY;
    private static string skinhead = Config.SNKEHEAD;
    private List<Point> _body = new List<Point>();
    private Point _head = new Point(Program.width / 2, Program.height / 2, skinhead);
    private Point _tail = new Point(Program.width / 2, Program.height / 2, " ");
    private int len = Config.SNAKELENGHT;
    private int color = Config.SNAKECOLOR;

    public void CreateSnake()
    {
        _body.Clear();
        direction[0] = 1;
        direction[1] = 0;
        _head = new Point(Program.width / 2, Program.height / 2, skinhead);
        _body.Add(_head);
        for (int i = 1; i < len; i++)
        {
            _body.Add(new Point(Program.width / 2 - i, Program.height / 2, skinbody));
        }

        _tail.x = _body[_body.Count - 1].x - 1;
        _tail.y = _body[_body.Count - 1].y;
    }

    public void Draw()
    {
        Console.ForegroundColor = (ConsoleColor)color;
        for (int i = 0; i < _body.Count; i++)
        {
            _body[i].Draw();
        }

        _tail.Draw();
        Console.ResetColor();
    }

    public void Move(ConsoleKeyInfo inuptkey)
    {
        _tail.x = _body[_body.Count - 1].x;
        _tail.y = _body[_body.Count - 1].y;
        for (int i = _body.Count - 1; i > 0; i--)
        {
            _body[i].x = _body[i - 1].x;
            _body[i].y = _body[i - 1].y;
        }

        if (inuptkey.Key == ConsoleKey.LeftArrow)
        {
            direction[0] = -1;
            direction[1] = 0;
        }
        else if (inuptkey.Key == ConsoleKey.RightArrow)
        {
            direction[0] = 1;
            direction[1] = 0;
        }
        else if (inuptkey.Key == ConsoleKey.UpArrow)
        {
            direction[1] = -1;
            direction[0] = 0;
        }
        else if (inuptkey.Key == ConsoleKey.DownArrow)
        {
            direction[1] = 1;
            direction[0] = 0;
        }

        _body[0].x += direction[0];
        _body[0].y += direction[1];
    }

    public bool CollideEnemy()
    {
        if (_body[0].x <= 0 || _body[0].x >= Program.width || _body[0].y <= 0 || _body[0].y >= Program.height)
        {
            return true;
        }

        for (int i = 1; i < _body.Count; i++)
        {
            if (_body[0].x == _body[i].x && _body[0].y == _body[i].y)
                return true;
        }

        return false;
    }

    public bool CollideFood()
    {
        if (_body[0].x == Food.apple.x && _body[0].y == Food.apple.y)
            return true;
        return false;
    }

    public void Grow()
    {
        _body.Add(new Point(_body[_body.Count - 1].x, _body[_body.Count - 1].y, skinbody));
        _tail.x = _body[_body.Count - 1].x;
        _tail.y = _body[_body.Count - 1].y;
    }
}