public class MenuProducer
{
    public void Show(List<string> optionList, string title = null)
    {
        if(title == null)
        {
            title = "Selct a option";
        }

        Console.WriteLine();
        Console.WriteLine(string.Format("{0}", title));

        for (int i = 0; i < optionList.Count(); i++)
        {
           Console.WriteLine(string.Format("{0}. {1}", i + 1, optionList[i]));
        }
    }

    public void ShowMainMenu()
    {
        List<string> mainOptions = new List<string>()
        {
            "Order",
            "Storage",
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

        string title = "Select an action";

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

        string title = "Select an object";

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

        Show(optionList);
    }

    public void ShowStorageOption()
    {
        List<string> storageOption = new List<string>()
        {
            "Summary",
            "Component",
            "Product",
        };

        Show(storageOption);
    }

    public void ShowStorageObjectOption()
    {
        List<string> option = new List<string>()
        {
            "List - At storage",
            "List - At vendor",
            "Add",
            "Remove"
        };

        Show(option);
    }
}