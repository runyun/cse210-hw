public class MenuProducer
{
    public void Show(List<string> optionList, string title = null, bool needInput = true, string question = null)
    {
        if(title == null)
        {
            title = "List";
        }
        Console.WriteLine();
        Console.WriteLine(title);

        for (int i = 0; i < optionList.Count(); i++)
        {
           Console.WriteLine(string.Format("{0}. {1}", i + 1, optionList[i]));
        }

        if(needInput)
        {
            ShowHint(question);
        }
    }

    private void ShowHint(string question)
    {
        if(question == null)
        {
            question = "Select an option: ";
        }

        Console.Write(string.Format("{0}: ", question));
    }

    public void ShowMainMenu()
    {
        List<string> mainOptions = new List<string>()
        {
            "Order",
            "Data Setting",
            "Quit"
        };

        string title = "Main Menu";

        Show(mainOptions, title);
    }

    public void ShowCRUDmenu()
    {
        List<string> menuOptions = new List<string>()
        {
            "Create",
            "Read",
            "Delete",
        };

        string title = "Action List";

        Show(menuOptions, title);
    }

    public void ShowObjectList()
    {
        List<string> objectList = new List<string>()
        {
            "Part",
            "Product",
            "Vendor",
            "Box",
            "Basket",
        };

        string title = "Object list";

        Show(objectList, title);
    }

    public void ShowOrderOption()
    {
        List<string> optionList = new List<string>()
        {
            "Create",
            "Complete",
            "List"
        };

        string title = "Action List";

        Show(optionList, title);
    }

}