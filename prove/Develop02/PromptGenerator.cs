public class PromptGenerator{
    public List<string> _prompts = new List<string>()
    {
        "One thing I've done today that I'm proud of",
        "Who do I want to give thanks to and why",
        "What makes me laugh today",
        "What is one thing that I think I can do better",
        "What do I need to change about my goal"
    };

    public string ChooseRandomPrompt()
    {
        string prompt = "";

        Random randomGenerator = new Random();
        int randomIndex = randomGenerator.Next(0, _prompts.Count());

        prompt = _prompts[randomIndex] + "? ";

        return prompt;
    }

}