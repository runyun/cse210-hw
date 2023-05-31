using System;

class Program
{
    static MenuProducer menuProducer = new MenuProducer();

    static void Main(string[] args)
    {

        int choice = 0;

        while (choice != 4)
        {
            menuProducer.ShowMainMenu();
            choice = int.Parse(Console.ReadLine());

            if(choice == 1)
            {
                Order();
            }
            else if(choice == 2)
            {
                DataSetting();
            }
            else if(choice == 3)
            {
                Console.WriteLine();
                Console.WriteLine("Good bye.");
            }
        }
    }
    
    private static void Order()
    {
        menuProducer.ShowOrderOption();
        int option = int.Parse(Console.ReadLine());

        Order orderManager = new Order();

        if(option == 1)
        {
           orderManager.Create(); 
        }
        else if(option == 2)
        {
           orderManager.Complete(); 
        }
        else if(option == 3)
        {
           orderManager.ShowList(); 
        }
    }

    private static void DataSetting()
    {
        menuProducer.ShowObjectList();
        int objectType = int.Parse(Console.ReadLine());

        menuProducer.ShowCRUDmenu();
        int actionType = int.Parse(Console.ReadLine());
        

        if(objectType == 1)
        {
            Part part = new Part();
            part.Proccess(actionType);
        } 
        else if(objectType == 2)
        {
            Product product = new Product();
            product.Proccess(actionType);
        }
        else if(objectType == 3)
        {
            Vendor vendor = new Vendor();
            vendor.Proccess(actionType);
        }
        else if(objectType == 4)
        {
            Box box = new Box();
            box.Proccess(actionType);
        }
        else if(objectType == 5)
        {
            Basket basket = new Basket();
            basket.Proccess(actionType);
        }

    }
}