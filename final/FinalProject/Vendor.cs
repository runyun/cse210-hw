public class Vendor : DataBaseObject
{
    private string _name, _contactor, _contact;

    public Vendor(){}
    public Vendor(string name, string contactor, string contact)
    {
        _name = name;
        _contactor = contactor;
        _contact = contact;
    }

    public override void Create()
    {
        Console.Write("What is the company name of the Vendor? ");
        string name = Console.ReadLine();

        Console.Write("What is the name of the contactor? ");
        string contactor = Console.ReadLine();

        Console.Write("What is the contact information of the contactor? ");
        string contact = Console.ReadLine();

        Vendor newVendor = new Vendor(name, contactor, contact);

        Save(newVendor);
    }

    public override string GetDescription()
    {
        return string.Format("{0}: {1}({2})", _name, _contactor, _contact);
    }

    public override string GetFilename()
    {
        return FileName.Vendor.ToString();
    }

    public override DataBaseObject ToObject(string dataString)
    {
        List<string> stringPart = dataString.Split("|").ToList();
        
        return new Vendor(stringPart[0], stringPart[1], stringPart[2]);
    }

    public override string ToString()
    {
        return string.Format("{0}|{1}|{2}", _name, _contactor, _contact);
    }
}