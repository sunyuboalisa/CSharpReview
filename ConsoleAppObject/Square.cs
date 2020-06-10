using System;

struct Square
{
    public double SideLength { get; set; }

    public double GetArea()
    {
        return Math.Pow(SideLength,2);
    }
}