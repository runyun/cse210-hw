
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
        Console.Write("What is the serial number of the Order? ");
        string serialNumber = Console.ReadLine();

        Console.Write("The vendor name? ");
        string vendorName = Console.ReadLine();

        Console.Write("What is the id of the Part? ");
        string partID = Console.ReadLine();

        Console.Write("How many are the Parts? ");
        int partAmount = int.Parse(Console.ReadLine());

        Console.Write("What is the product id? ");
        string productID = Console.ReadLine();

        Console.Write("What is the size of basket? ");
        string basketSize = Console.ReadLine();

        Console.Write("How many baskets used? ");
        int basketAmount = int.Parse(Console.ReadLine());

        Order newOrder = new Order();

        Save(newOrder);
    }

    public override string GetDescription()
    {
        return string.Format(@"{
            == {0} == {11}
            Vendor: {1}
            Part {2}({3}) -> Product {4}
            Basket: {5}(6)
            Delivery Date: {7}
            Success: {8}
            Fail: {9}
            Return: {10}
        }", _serialNumber, _vendorName, _partID, _partAmount, _productID, _basketSize, _basketAmount, _deliveryDate,_successAmount, _failAmount, _returnAmount, _isComplete);
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
        return string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", _serialNumber, _isComplete, _vendorName, _partID, _partAmount, _productID, _basketSize, _basketAmount, _deliveryDate, _successAmount, _failAmount, _returnAmount);
    }

    public void Complete()
    {

    }

    public void ShowList()
    {

    }
}
