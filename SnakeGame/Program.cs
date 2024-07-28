using System;

namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Snake game = new Snake(11, 11, 0.5f);

            game.Start();
        }
    }
}
