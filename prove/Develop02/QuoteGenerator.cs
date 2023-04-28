public class QuoteGenerator
{
    List<string> _quotes = new List<string>()
    {
        "We did not come to this earth to gain our worth – we brought it with us. - Ardeth G Kapp",
        "Even if “everyone is doing it” wrong is never right. – Russell M Nelson",
        "Pray to have eyes to see God’s hand in your life and in the world around you. – Russell M Nelson",
        "He rarely moves the mountains in front of us but he always helps us climb them. – Sheri Dew",
        "By helping others come unto Him you will find you have come unto Him yourself. – Henry B. Eyring",
        "As you draw nearer to the Lord, He will guide you to become the best version of yourself. – M. Russell Ballard",
        "God never loses sight of our eternal potential, even when we do. – Carol M. Stephens",
        "Never let a problem to be solved become more important than a person to be loved. – Thomas S. Monson",
        "Good timber does not grow with ease. The stronger the wind the stronger the trees. – Thomas S. Monson",
        "If you are on the right path, it will always be uphill. – Henry B. Eyring",
    };

    public string ChooseRandomQuote()
    {
        string quote = _quotes[new Random().Next(0, _quotes.Count)];

        return quote;
    }     
}