Tester.Test();

public interface ICloneable
{
    object Clone();
}

public class Cat : ICloneable
{
    public string name;
    public string weight;
    private string type;
    public Cat(string name, string weight, string type)
    {
        this.name = name;
        this.weight = weight;
        this.type = type;
    }
    public void LogData()
    {
        Console.WriteLine($"{name},{weight},{type}");
    }

    public object Clone()
    {
        return new Cat(name, weight, type);
    }
}

public class Clowder
{
    private List<ICloneable> cats;
    public Clowder()
    {
        cats = new List<ICloneable>();
    }
    public void Add(ICloneable clone) => cats.Add(clone);
    public void Remove(ICloneable clone) => cats.Remove(clone);
    public ICloneable GetById(int index) => cats[index];
    public int GetNumberOfCats() => cats.Count;
}

public static class Tester
{
    public static void Test()
    {
        Cat originalCat = new Cat("Fluffy", "5kg", "Persian");

        Cat clonedCat = (Cat)originalCat.Clone();

        Console.WriteLine("Original cat:");
        originalCat.LogData();
        Console.WriteLine("Cloned cat:");
        clonedCat.LogData();

        Clowder clowder = new Clowder();
        clowder.Add(originalCat);
        clowder.Add(clonedCat);

        Console.WriteLine("\nCats in clowder:");
        for(int i = 0; i < clowder.GetNumberOfCats(); i++)
        {
            Cat cat = (Cat)clowder.GetById(i);
            cat.LogData();
        }
    }
}