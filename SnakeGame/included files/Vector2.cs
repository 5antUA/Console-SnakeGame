public struct Vector2
{
    public int x;
    public int y;

    public static Vector2 Up = new Vector2(0, -1);
    public static Vector2 Down = new Vector2(0, 1);
    public static Vector2 Right = new Vector2(1, 0);
    public static Vector2 Left = new Vector2(-1, 0);

    public Vector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector2 operator +(Vector2 first, Vector2 second)
    {
        return new Vector2(first.x + second.x, first.y + second.y);
    }

    public static Vector2 operator -(Vector2 first, Vector2 second)
    {
        return new Vector2(first.x - second.x, first.y - second.y);
    }

    public static Vector2 operator *(Vector2 first, int value)
    {
        return new Vector2(first.x * value, first.y * value);
    }

    public static bool operator ==(Vector2 first, Vector2 second)
    {
        return (first.x == second.x) && (first.y == second.y);
    }

    public static bool operator !=(Vector2 first, Vector2 second)
    {
        return !(first == second);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Vector2))
            return false;

        return this == (Vector2)obj;
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode();
    }
}