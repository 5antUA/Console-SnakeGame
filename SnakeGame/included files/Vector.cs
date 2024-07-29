public struct Vector
{
    public int x;
    public int y;

    public static Vector Up = new Vector(0, -1);
    public static Vector Down = new Vector(0, 1);
    public static Vector Right = new Vector(1, 0);
    public static Vector Left = new Vector(-1, 0);

    public Vector(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector operator +(Vector first, Vector second)
    {
        return new Vector(first.x + second.x, first.y + second.y);
    }

    public static Vector operator -(Vector first, Vector second)
    {
        return new Vector(first.x - second.x, first.y - second.y);
    }

    public static Vector operator *(Vector first, int value)
    {
        return new Vector(first.x * value, first.y * value);
    }

    public static bool operator ==(Vector first, Vector second)
    {
        return (first.x == second.x) && (first.y == second.y);
    }

    public static bool operator !=(Vector first, Vector second)
    {
        return !(first == second);
    }

    public override bool Equals(object obj)
    {
        if (!(obj is Vector))
            return false;

        return this == (Vector)obj;
    }

    public override int GetHashCode()
    {
        return x.GetHashCode() ^ y.GetHashCode();
    }
}