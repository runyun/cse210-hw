public class Product : DataBaseObject
{
    private string _id;

    public Product(){}
    public Product(string id)
    {
        _id = id;
    }

    public override void Create()
    {
        Console.WriteLine("What is the ID of the Product? ");
        string id = Console.ReadLine();

        Product newProduct = new Product(id);

        Save(newProduct);
    }

    public override string GetDescription()
    {
        return _id;
    }

    public override string GetFilename()
    {
        return FileName.Product.ToString();
    }

    public override DataBaseObject ToObject(string dataString)
    {
        return new Product(dataString);
    }

    public override string ToString()
    {
        return _id;
    }
}