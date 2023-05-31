public class Basket : DataBaseObject
{
    private string _size;

    public Basket(){}
    public Basket(string size)
    {
        _size = size;
    }

    public override void Create()
    {
        Console.WriteLine("What is the size of the Basket? (Should be a string)");
        string size = Console.ReadLine();

        Basket newBasket = new Basket(size);

        Save(newBasket);
    }

    public override string GetDescription()
    {
        return _size;
    }

    public override string GetFilename()
    {
        return FileName.Basket.ToString();
    }

    public override DataBaseObject ToObject(string dataString)
    {
        return new Basket(dataString);
    }

    public override string ToString()
    {
        return _size;
    }
}