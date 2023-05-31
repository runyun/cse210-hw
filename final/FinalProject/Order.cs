
public class Order : DataBaseObject
{
    private string _serialNumber;
    private bool _isComplete = false;
    private string _vendorName;
    private string _partID;
    private int _partAmount;
    private string _productID;
    private string _basketSize;
    private int _basketAmount;
    private string _deliveryDate;
    private int _successAmount = 0;
    private int _failAmount = 0;
    private int _returnAmount = 0;
  

    public Order(){}
    public Order(
        string serialNumber,
        bool isComplete,
        string vendorName,
        string partID,
        int partAmount,
        string productID,
        string basketSize,
        int basketAmount,
        string deliveryDate,
        int successAmount,
        int failAmount,
        int returnAmount)
    {
        _serialNumber = serialNumber;
        _isComplete = isComplete;
        _vendorName = vendorName;
        _partID = partID;
        _partAmount = partAmount;
        _productID = productID;
        _basketSize = basketSize;
        _basketAmount = basketAmount;
        _deliveryDate = deliveryDate;
        _successAmount = successAmount;
        _failAmount = failAmount;
        _returnAmount = returnAmount;
    }
    public override void Create()
    {
        MenuProducer menuProducer = new MenuProducer();

        Console.Write("What is the serial number of the Order? ");
        string serialNumber = Console.ReadLine();

        string vendorName = GetOptionName(FileName.Vendor, "Vendor");

        string partID = GetOptionName(FileName.Part, "What is the id of the Part");

        Console.Write("How many are the Parts? ");
        int partAmount = int.Parse(Console.ReadLine());

        string productID = GetOptionName(FileName.Product, "What is the product id ");

        string basketSize = GetOptionName(FileName.Basket, "What is the size of basket? ");

        Console.Write("How many baskets used? ");
        int basketAmount = int.Parse(Console.ReadLine());

        Order newOrder = new Order();
        newOrder._serialNumber = serialNumber;
        newOrder._vendorName = vendorName;
        newOrder._partID = partID;
        newOrder._partAmount = partAmount;
        newOrder._productID = productID;
        newOrder._basketSize = basketSize;
        newOrder._basketAmount = basketAmount;
        newOrder._deliveryDate = DateTime.Now.ToShortDateString();

        Save(newOrder);
    }

    public override string GetDescription()
    {
        string pattern = 
        @"
== {0} == 
Complete: {11}
Vendor: {1}
Part {2}({3}) -> Product {4}
Basket: {5} x {6}
Delivery Date: {7}
Success: {8}
Fail: {9}
Return: {10}";
        
        return string.Format(pattern, _serialNumber, _vendorName, _partID, _partAmount, _productID, _basketSize, _basketAmount, _deliveryDate, _successAmount, _failAmount, _returnAmount, _isComplete);
    }

    public override string GetFilename()
    {
        return FileName.Order.ToString();
    }

    public override DataBaseObject ToObject(string dataString)
    {
        List<string> partList = dataString.Split("|").ToList();
        string serialNumber = partList[0];
        bool isComplete = partList[1] == "False" ? false : true;
        string vendorName = partList[2];
        string partID = partList[3];
        int partAmount = int.Parse(partList[4]);
        string productID = partList[5];
        string basketSize = partList[6];
        int basketAmount = int.Parse(partList[7]);
        string deliveryDate = partList[8];
        int successAmount = int.Parse(partList[9]);
        int failAmount = int.Parse(partList[10]);
        int returnAmount = int.Parse(partList[11]);

        return new Order(serialNumber, isComplete, vendorName, partID, partAmount, productID, basketSize, basketAmount, deliveryDate, successAmount, failAmount, returnAmount);
    }

    public override string ToString()
    {
        return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}", _serialNumber, _isComplete, _vendorName, _partID, _partAmount, _productID, _basketSize, _basketAmount, _deliveryDate, _successAmount, _failAmount, _returnAmount);
    }

    public void Complete()
    {
        List<DataBaseObject> orderList = Read();
        List<Order> progressingList = (from Order order in orderList where !order._isComplete select order).ToList();
        
        List<string> optionList = (from order in progressingList select order.GetDescription()).ToList(); 

        string question = "Select an order";
        new MenuProducer().Show(optionList, "The list", question: question);

        int option = int.Parse(Console.ReadLine());
        int editIndex = option - 1;

        Console.Write("Success amount? ");
        int successAmount = int.Parse(Console.ReadLine());

        Console.Write("Failed amount? ");
        int failAmount = int.Parse(Console.ReadLine());

        Console.Write("Return amount? ");
        int returnAmount = int.Parse(Console.ReadLine());

        string orderNumber = progressingList[editIndex]._serialNumber;

        Order completeOrder = (from Order order in orderList where order._serialNumber == orderNumber select order).First();

        orderList.Remove(completeOrder);
    
        completeOrder._isComplete = true;
        completeOrder._successAmount = successAmount;
        completeOrder._failAmount = failAmount;
        completeOrder._returnAmount = returnAmount;

        orderList.Add(completeOrder);

        List<string> dataStringList = (from order in orderList select order.ToString()).ToList();

        FileManager fileManager = GetFileManager();
        fileManager.Save(dataStringList);
    }
    public void ShowList()
    {
        List<DataBaseObject> objectList = Read();
        new MenuProducer().Show(ReadDescription(objectList), "The list", false);
    }

    private string GetOptionName(FileName filename, string question)
    {
        FileManager fileManager =  new FileManager(filename.ToString());
        List<string> dataList = fileManager.Load();

        List<string> nameList = new List<string>();
        foreach (string data in dataList)
        {
            if(data.Contains("|"))
            {
                nameList.Add(data.Substring(0, data.IndexOf("|")));
            }
            else
            {
                nameList.Add(data);
            }
        }

        new MenuProducer().Show(nameList, question);

        int option = int.Parse(Console.ReadLine());
        int index = option - 1;

        return nameList[index];
    }
}
