public class StorageManager
{
    private Dictionary<Part, int> _partDictionary = new Dictionary<Part, int>();
    private Dictionary<Product, int> _productDictionary = new Dictionary<Product, int>();

    public StorageManager(){}
    public StorageManager(Dictionary<Part, int> partDictionary, Dictionary<Product, int> productDictionary)
    {
        _partDictionary = partDictionary;
        _productDictionary = productDictionary;
    } 

    public void ShowSummary()
    {
        // how many component
        // how many product
        // how many basket are outside

    }

    public void ComponentRelate()
    {
        
        // storage
        // vendor
        
    }

    public void ProductRelate()
    {

    }

    public void ShowBasketList()
    {

    }
}