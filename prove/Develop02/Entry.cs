public class Entry
{

    public string _date;
    public string _content;
    public string _prompt;

    public void DisplayEntry()
    {
        Console.WriteLine();
        Console.WriteLine($"== {_date} ==");
        Console.WriteLine(_prompt);
        Console.WriteLine($"> {_content}");
        Console.WriteLine();
    }

    public Entry LoadEntry(string entryText)
    {
        string[] parts = entryText.Split("|");

        string date = parts[0];
        string prompt = parts[1];
        string content = parts[2];

        Entry entry = new Entry().CreateEntry(date, prompt, content);

        return entry;
    }

    public Entry CreateEntry(string date, string prompt, string content)
    {
        Entry entry = new Entry();

        entry._date = date;
        entry._prompt = prompt;
        entry._content = content;

        return entry;
    }
}