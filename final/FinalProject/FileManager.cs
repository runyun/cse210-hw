public class FileManager
{
    private string _filename;

    public FileManager(string filename)
    {
        _filename = filename + ".txt";
    }

    public void Save(string dataString)
    {
        using(StreamWriter outputFile = File.AppendText(_filename))
        {
            outputFile.WriteLine(dataString);
        }

        Console.WriteLine();
        Console.WriteLine("File Saved");
    }

    public void Save(List<string> dataStringList)
    {
        using(StreamWriter outputFile = new StreamWriter(_filename))
        {
            foreach(string dataString in dataStringList)
            {
                outputFile.WriteLine(dataString);
            }
        }
    }

    public void Delete(int index)
    {
        List<string> fileLoadedList = Load();

        fileLoadedList.RemoveAt(index);

        Save(fileLoadedList);

        Console.WriteLine();
        Console.WriteLine("Object Deleted");
    }

    public List<string> Load()
    {
        List<string> fileLoadedList = File.ReadAllLines(_filename).ToList();
        return fileLoadedList;
    }
}