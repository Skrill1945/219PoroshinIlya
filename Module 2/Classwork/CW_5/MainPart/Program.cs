using System;
abstract class RightFigure
{
    public int Side { get; private set; }
    static RightFigure() => Console.WriteLine(1);
    public RightFigure(int s)
    {
        Side = s;
        Console.WriteLine(3);
    }
    public abstract double Area { get; }
    public abstract int Perimetr();
    public override string ToString() => $"Side = {Side} Area = {Area:f2} P = {Perimetr()}";
}
class RightTriangle : RightFigure
{
    public RightTriangle(int s) : base(s) => Console.WriteLine(4);
    static RightTriangle() => Console.WriteLine(2);
    public override double Area => Side * Side * Math.Sqrt(3) / 4;
    public override int Perimetr() => 3 * Side;
}
class Square : RightFigure
{
    public Square(int s) : base(s) { }
    static Square()
    {
        Console.WriteLine(3);
    }
    public override double Area => Side * Side;
    public override int Perimetr() => 4 * Side;
}
class Program
{
    public static void Main()
    {
        // 1 3 4 3
        RightFigure triangle = new RightTriangle(10);
        RightFigure square = new Square(10);
        //Random random = new Random();
        //RightFigure[] figures = new RightFigure[10];
        //for (int i = 0; i < 5; i++)
        //    figures[i] = new RightTriangle(random.Next(10));
        //for (int i = 5; i < 10; i++)
        //    figures[i] = new Square(random.Next(10));
        //for (int i = 0; i < 10; i++)
        //{
        //    Console.WriteLine(figures[i]);
        //}
    }
}