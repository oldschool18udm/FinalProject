using System;
using System.Threading;

namespace Snake;

class Program
{
    public static int width = Config.BOARDWIDTH;
    public static int height = Config.BOARDHEIGHT;
    public static int gamespeed = Config.GAMESPEED;
    public static int state = 0;
    private static ConsoleKeyInfo inuptkey;
    public static Walls walls = new Walls();
    public static Hero snake = new Hero();
    public static Food apple = new Food();
    public static ScoreBoard scoreboard = new ScoreBoard();
    public static int playerScore = 0;
    public static int lives = Config.STARTLIVES;
    public static string playerName = "Player";
    public static int bestScore = 0;

    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        while (true)
        {
            if (state == 0)
            {
                MainMenu();
            }

            if (state == 1)
                Game();
            if (state == 2)
            {
                EndGame();
            }
        }
    }

    private static void Game()
    {
        Console.Clear();
        walls.Draw(0, 0, width, height);
        snake.CreateSnake();
        snake.Draw();
        apple.Spawn();
        apple.Draw();
        while (true)
        {
            scoreboard.DrawGameState();
            if (Console.KeyAvailable)
            {
                inuptkey = Console.ReadKey();
            }

            snake.Move(inuptkey);
            snake.Draw();
            apple.Draw();
            if (snake.CollideEnemy())
            {
                if (bestScore < playerScore)
                {
                    bestScore = playerScore;
                }

                if (lives > 0)
                {
                    Console.SetCursorPosition(10, 5);
                    Console.Write("Missed chance!");
                    inuptkey = Console.ReadKey();
                    ResetGame();
                    lives--;
                }
                else
                {
                    state = 2;
                    break;
                }
            }

            if (snake.CollideFood())
            {
                apple.Spawn();
                snake.Grow();
                playerScore++;
            }

            Thread.Sleep(gamespeed);
        }
    }

    private static void MainMenu()
    {
        bestScore = 0;
        walls.Draw(0, 0, width, height);
        Console.SetCursorPosition(10, 5);
        Console.WriteLine("Welcome to Snake Game!");
        Console.SetCursorPosition(10, 6);
        Console.Write("Input your name: ");
        playerName = Console.ReadLine() + "";
        Console.Clear();
        walls.Draw(0, 0, width, height);
        Console.SetCursorPosition(10, 5);
        Console.Write($"Hello {playerName}. Press Enter to continue...");
        while (true)
        {
            if (Console.KeyAvailable)
            {
                inuptkey = Console.ReadKey();
                if (inuptkey.Key == ConsoleKey.Enter)
                {
                    state = 1;
                    break;
                }
            }
        }
    }

    private static void EndGame()
    {
        Console.Clear();
        walls.Draw(0, 0, width, height);
        Console.SetCursorPosition(10, 5);
        Console.Write("Oops... Game Over.");
        Console.SetCursorPosition(10, 6);
        Console.Write($"{playerName},your best score is {bestScore}.");
        Console.SetCursorPosition(10, 7);
        Console.Write("Press Esc to exit,");
        Console.SetCursorPosition(10, 8);
        Console.Write("Enter to continue...");
        while (true)
        {
            if (Console.KeyAvailable)
            {
                inuptkey = Console.ReadKey();
                if (inuptkey.Key == ConsoleKey.Enter)
                {
                    lives = Config.STARTLIVES;
                    ResetGame();
                    break;
                }

                if (inuptkey.Key == ConsoleKey.Escape)
                    Environment.Exit(0);
            }
        }
    }

    public static void ResetGame()
    {
        Console.Clear();
        walls.Draw(0, 0, width, height);
        snake.CreateSnake();
        apple.Spawn();
        state = 0;
        playerScore = 0;
    }
}