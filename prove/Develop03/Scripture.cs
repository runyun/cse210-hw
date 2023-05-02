public class Scripture
{

    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private List<int> _removedIndex = new List<int>();
    private int _hideAmount = 3;
    
    public Scripture(Reference reference, string scriptureString)
    {
        _reference = reference;

        string[] wordList = scriptureString.Split(" ");
        foreach (string word in wordList)
        {
            Word addWord = new Word(word);
            _words.Add(addWord);
        }
    }
    public void HideWords()
    {
        Random randomGenerator = new Random();

        int hideCount = _hideAmount;

        while(hideCount > 0 && !IsCompletelyHidden())
        {
            int hideIndex = randomGenerator.Next(_words.Count());

            if(_words[hideIndex].IsHidden() == false)
            {
                _words[hideIndex].Hide();
                _removedIndex.Add(hideIndex);

                hideCount --;
            }
        }
    }

    public string GetRenderedText()
    {
        var scriptureWordList = from word in _words select word.GetRenderedText();
        string scriptureString = string.Join(" ", scriptureWordList);
 
        string referenceString = _reference.GetReferenceText();

        return $"{referenceString} {scriptureString}";
    }

    public bool IsCompletelyHidden()
    {
        List<Word> nonHiddenWord = (from data in _words where data.IsHidden() == false select data).ToList();

        return nonHiddenWord.Count == 0 ? true : false;
    }

    public void RecoverWords()
    {
        if(_removedIndex.Count() != 0)
        {
            int beginIndex = _removedIndex.Count() - _hideAmount;

            List<int> rangeIndex = _removedIndex.GetRange(beginIndex, _hideAmount);

            foreach (int index in rangeIndex)
            {
               _words[index].Show(); 
            }

            _removedIndex.RemoveRange(beginIndex, _hideAmount);
        }
    }
}