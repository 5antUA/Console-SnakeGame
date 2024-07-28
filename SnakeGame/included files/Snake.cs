using System;
using System.Collections.Generic;
using System.Threading;

public class Snake
{
    private bool _isAlive;
    private int _score;
    private int _difficulty;
    private Vector _headPosition;
    private Vector _applePosition;
    private Vector _direction;
    private List<Vector> _tailList;

    public int AreaWidth { get; private set; }
    public int AreaHeight { get; private set; }


    public Snake(int width, int height, float difficulty = 1)
    {
        AreaWidth = width;
        AreaHeight = height;

        _difficulty = (int)(difficulty * 1000);
        _headPosition = new Vector(AreaWidth / 2, AreaHeight / 2);
        _direction = Vector.Right;
        _tailList = new List<Vector>();
    }

    public void Start()
    {
        _isAlive = true;
        GenerateApple();

        while (_isAlive)
        {
            DisplayArea();
            Thread.Sleep(_difficulty);
            Console.Clear();
            MoveSnake();
            OnDefeat();
            OnEatApple();
        }
    }

    private void DisplayArea()
    {
        Console.WriteLine(this);

        for (int y = 0; y < AreaHeight; y++)
        {
            for (int x = 0; x < AreaWidth; x++)
            {
                if (x == 0 || y == 0 || x == AreaWidth - 1 || y == AreaHeight - 1)
                {
                    // borders
                    Console.Write("# ");
                }
                else if (x == _headPosition.x && y == _headPosition.y)
                {
                    // snake head
                    Console.Write("@ ");
                }
                else if (_tailList.Contains(new Vector(x, y)))
                {
                    // snake tail
                    Console.Write("o ");
                }
                else if (x == _applePosition.x && y == _applePosition.y)
                {
                    // apple
                    Console.Write("* ");
                }
                else
                {
                    // empty space
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private void MoveSnake()
    {
        if (Console.KeyAvailable)
        {
            var input = Console.ReadKey(intercept: true);

            switch (input.Key)
            {
                case ConsoleKey.A: _direction = Vector.Left;
                    break;
                case ConsoleKey.D: _direction = Vector.Right;
                    break;
                case ConsoleKey.W: _direction = Vector.Up;
                    break;
                case ConsoleKey.S: _direction = Vector.Down;
                    break;
            }
        }

        if (_tailList.Count > 0)
        {
            for (int i = _tailList.Count - 1; i > 0; i--)
            {
                _tailList[i] = _tailList[i - 1];
            }
            _tailList[0] = _headPosition;
        }

        _headPosition += _direction;
    }

    private void OnEatApple()
    {
        if (_headPosition == _applePosition)
        {
            _score++;
            _tailList.Add(_headPosition);
            GenerateApple();
        }
    }

    private void GenerateApple()
    {
        int randX, randY;

        do
        {
            randX = new Random().Next(1, AreaWidth - 1);
            randY = new Random().Next(1, AreaHeight - 1);
        }
        while (_headPosition == new Vector(randX, randY) || 
                _tailList.Contains(new Vector(randX, randY)));

        _applePosition = new Vector(randX, randY);
    }

    private void OnDefeat()
    {
        if (_headPosition.x == 0 || _headPosition.y == 0 ||
            _headPosition.x == AreaWidth - 1 || _headPosition.y == AreaHeight - 1 ||
            _tailList.Contains(_headPosition))
        {
            _isAlive = false;
        }
    }

    public override string ToString()
    {
        string gameStateInfo =
            $"Head position : ({_headPosition.x}; {_headPosition.y}) \n" +
            $"Area size : {AreaHeight}x{AreaWidth} \n" +
            $"Player score : {_score}  \n";

        return gameStateInfo;
    }
}