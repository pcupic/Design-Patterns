Tester.Test();

public interface ICoffee
{
    double GetCost();
    String GetDescription();
}

public class Espresso : ICoffee
{

    public double GetCost()
    {
        return 1.99;
    }

    public String GetDescription()
    {
        return "Espresso";
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee coffee;

    public CoffeeDecorator(ICoffee coffee)
    {
        this.coffee = coffee;
    }
    public virtual double GetCost() => coffee.GetCost();
    public virtual String GetDescription() => coffee.GetDescription();
}

public class Milk : CoffeeDecorator
{

    public Milk(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return base.GetCost() + 0.4;
    }
    public override string GetDescription()
    {
        return base.GetDescription() + " with milk";
    }
}

public static class Tester
{
    public static void Test()
    {
        ICoffee espresso = new Espresso();
        Console.WriteLine($"{espresso.GetDescription()} costs {espresso.GetCost()}");

        ICoffee milkEspresso = new Milk(espresso);
        Console.WriteLine($"{milkEspresso.GetDescription()} costs {milkEspresso.GetCost()}");
    }
}