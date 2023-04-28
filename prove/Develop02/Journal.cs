using System.IO; 

public class Journal 
{
    public List<Entry> _entries = new List<Entry>();

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
        }
    }

    public void SaveJournal(string filename)
    {
        string spliter = "|";

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}{spliter}{entry._prompt}{spliter}{entry._content}");
            }
        }
    }

    public void LoadJournal(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        
        foreach (string line in lines)
        {
            Entry entry = new Entry().LoadEntry(line);

            _entries.Add(entry);
        }
    }
}