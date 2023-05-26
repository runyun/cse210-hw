public class Box : DataBaseObject
{
    private int _size;

    public Box(){}
    public Box(int size)
    {
        _size = size;
    }

    public override string GetFilename()
    {
        return FileName.Box.ToString();
    }

    public override DataBaseObject ToObject(string dataString)
    {
        Box newBox = new Box(int.Parse(dataString));
        return newBox;
    }

    public override string ToString()
    {
        return _size.ToString();
    }

    public override void Create()
    {
        Console.WriteLine("What is the size of the box? (should be a number)");
        int size = int.Parse(Console.ReadLine());

        Box newBox = new Box(size);

        Save(newBox);
    }

    public override string GetDescription()
    {
        return _size.ToString();
    }

}