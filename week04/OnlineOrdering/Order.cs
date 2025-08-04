public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double productTotal = _products.Sum(p => p.GetTotalCost());
        double shipping = _customer.LivesInUSA() ? 5 : 35;
        return productTotal + shipping;
    }

    public string GetPackingLabel()
    {
        return string.Join("\n", _products.Select(p => p.GetPackingLabel()));
    }

    public string GetShippingLabel()
    {
        return _customer.GetShippingLabel();
    }
}