using System;

class Program
{
    static void Main(string[] args)
    {
        Address addr1 = new Address("123 Main St", "Provo", "UT", "USA");
        Customer cust1 = new Customer("Alice Johnson", addr1);
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Book", "B001", 12.99, 2));
        order1.AddProduct(new Product("Pen", "P101", 1.50, 5));

        Console.WriteLine("Order 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.GetTotalCost():0.00}\n");

        Address addr2 = new Address("45 Rue de Paris", "Paris", "Île-de-France", "France");
        Customer cust2 = new Customer("Jean Dupont", addr2);
        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("Notebook", "N777", 8.75, 3));
        order2.AddProduct(new Product("Highlighter", "H333", 2.25, 4));

        Console.WriteLine("Order 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.GetTotalCost():0.00}");
    }
}