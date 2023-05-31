
public abstract class DataBaseObject
{
    private string _filename;
    private FileManager _fileManager;

    public DataBaseObject()
    {
        _filename = GetFilename();
        _fileManager = new FileManager(_filename);
    }

    public List<DataBaseObject> Read()
    {
        List<string> fileLoadedList = _fileManager.Load();

        List<DataBaseObject> objectList = new List<DataBaseObject>();

        foreach (string dataString in fileLoadedList)
        {
           objectList.Add(ToObject(dataString));
        }

        return objectList;
    }

    public abstract void Create();
    
    public void Proccess(int actionType)
    {
        MenuProducer menuProducer = new MenuProducer();

        if(actionType == 1)
        {
            Create();
        }
        else if(actionType == 2)
        {
            List<DataBaseObject> objectList = Read();

            if(objectList.Count != 0)
            {
                menuProducer.Show(ReadDescription(objectList), "The list", false);
            }
            else
            {
                Console.WriteLine("No data");
            }
        }
        else if(actionType == 3)
        {
            List<DataBaseObject> objectList = Read();

            string question = "Which one you want to delete";
            menuProducer.Show(ReadDescription(objectList), "The list", question: question);

            int deleteIndex = int.Parse(Console.ReadLine()) - 1;

            _fileManager.Delete(deleteIndex);
        }
    }

    public List<string> ReadDescription(List<DataBaseObject> objectList)
    {
        return (from data in objectList select data.GetDescription()).ToList();
    }

    public abstract DataBaseObject ToObject(string dataString);
    public abstract string GetFilename();
    public abstract string GetDescription();
    public FileManager GetFileManager()
    {
        return _fileManager;
    }

    public void Save(DataBaseObject newObject)
    {
        _fileManager.Save(newObject.ToString());
    }
}