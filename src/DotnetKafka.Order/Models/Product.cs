namespace DotnetKafka.Order.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"ProductName:{Name} ,Price :{Price}";
    }
}