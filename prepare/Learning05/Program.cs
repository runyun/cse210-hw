using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square square = new Square("white", 5);

        Rectangle rectangle = new Rectangle("blue", 7, 2);

        Circle circle = new Circle("yellow", 4);

        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine();
            Console.WriteLine(shape.GetArea());
            Console.WriteLine(shape.GetColor());
        }
        
    }
}