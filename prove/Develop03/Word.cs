public class Word
{
    private string _word;
    private bool _hide;

    public Word(string word) 
    {
        _word = word;
    }
    public void Hide()
    {
        _hide = true;
    }

    public void Show()
    {
        _hide = false;
    }
    public bool IsHidden()
    {
        return _hide;
    }

    public string GetRenderedText()
    {
        if(_hide)
        {
            string hideText = "_";
            string hideString = "";

            for(int i = 0; i < _word.Count(); i++)
            {
                hideString += hideText; 
            }

            return hideString;
        }
        else
        {
            return _word;
        }
    }
}