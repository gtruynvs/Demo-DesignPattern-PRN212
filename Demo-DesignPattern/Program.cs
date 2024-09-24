using Demo_DesignPattern;
using System.Linq;

namespace Demo_DesignPattern
{

}
public interface IOrderFactory
{
    IOrder CreateOrder();
    IPayment CreatePayment();
    IShipping CreateShipping();
}

public interface IOrder
{
    void ProcessOrder();
}
public interface IPayment
{
    void ProcessPayment();
}
public interface IShipping
{
    void ShipOrder();
}
public class DomesticOrderFactory : IOrderFactory
{
    public IOrder CreateOrder()
    {
        return new DomesticOrder();
    }

    public IPayment CreatePayment()
    {
        return new DomesticPayment();
    }

    public IShipping CreateShipping()
    {
        return new DomesticShipping();
    }
}

public class InternationalOrderFactory : IOrderFactory
{
    public IOrder CreateOrder()
    {
        return new InternationalOrder();
    }

    public IPayment CreatePayment()
    {
        return new InternationalPayment();
    }

    public IShipping CreateShipping()
    {
        return new InternationalShipping();
    }
}

public class DomesticOrder : IOrder
{
    public void ProcessOrder()
    {
        Console.WriteLine("Processing Domestic Order..........");
    }
}

public class InternationalOrder : IOrder
{
    public void ProcessOrder()
    {
        Console.WriteLine("Processing International Order..........");
    }
}

public class DomesticPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing Domestic Payment..........");
    }
}

public class InternationalPayment : IPayment
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing International Payment..........");
    }
}

public class DomesticShipping : IShipping
{
    public void ShipOrder()
    {
        Console.WriteLine("Shipping Domestic Order..........");
    }
}

public class InternationalShipping : IShipping
{
    public void ShipOrder()
    {
        Console.WriteLine("Shipping International Order..........");
    }
}

//Prototype Pattern
public abstract class Car
{
    protected int basePrice = 0, onRoadPrice = 0;
    public string ModelName { get; set; }
    public int BasePrice { get => basePrice; set => basePrice = value; }
    public int OnRoadPrice { get => onRoadPrice; set => onRoadPrice = value; }
    public static int SetAdditionalPrice()
    {
        Random random = new Random();
        int additionalPrice = random.Next(200_000, 500_000);
        return additionalPrice;
    }
    public abstract Car Clone();

}
public class Mustang : Car
{
    public Mustang(string model) => (ModelName, BasePrice) = (model, 200_000);
    public override Car Clone() => this.MemberwiseClone() as Mustang;
}
public class Bentley : Car
{
    public Bentley(string model) => (ModelName, BasePrice) = (model, 300_000);
    public override Car Clone() => this.MemberwiseClone() as Bentley;
}

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1. Demo Factory");
            Console.WriteLine("2. Demo Abstract");
            Console.WriteLine("3. Demo Protype");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            int n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("***Factory Pattern Demo***\n");
                    List<AnimalFactory> animalFactoryList = new List<AnimalFactory> {
                        new TigerFactory(),
                        new LionFactory()
                    };
                    foreach (var animal in animalFactoryList)
                    {
                        animal.CreateAnimal().AboutMe();
                    }
                    break;
                case 2:
                    IOrderFactory domesticFactory = new DomesticOrderFactory();
                    IOrder domesticOrder = domesticFactory.CreateOrder();
                    IPayment domesticPayment = domesticFactory.CreatePayment();
                    IShipping domesticShipping = domesticFactory.CreateShipping();

                    domesticOrder.ProcessOrder();
                    domesticPayment.ProcessPayment();
                    domesticShipping.ShipOrder();
                    break;
                case 3:
                    Console.WriteLine("***Prototype Pattern Demo***\n");
                    Car mustang = new Mustang("Mustang EcoBoost");
                    Car bentley = new Bentley("Continental GT Mulliner");
                    Console.WriteLine($"Car is: {mustang.ModelName}, Base Price: {mustang.BasePrice}");
                    Console.WriteLine($"Car is: {bentley.ModelName}, Base Price: {bentley.BasePrice}");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}

