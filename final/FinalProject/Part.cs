public class Part : DataBaseObject
{
    private string _id;
  

    public Part(){}
    public Part(string id)
    {
        _id = id;
    }

    public override void Create()
    {
        Console.WriteLine("What is the ID of the Part? ");
        string id = Console.ReadLine();

        Part newPart = new Part(id);

        Save(newPart);
    }

    public override string GetDescription()
    {
        return _id;
    }

    public override string GetFilename()
    {
        return FileName.Part.ToString();
    }

    public override DataBaseObject ToObject(string dataString)
    {
        return new Part(dataString);
    }

    public override string ToString()
    {
        return _id;
    }
}