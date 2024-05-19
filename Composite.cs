public interface IItem
{
    public string Name { get; }
    public int Price { get; }
}

public class Item : IItem
{
    string name;
    int price;
    public Item(string name, int price) { this.name = name; this.price = price; }
    public string Name { get { return name; } }
    public int Price { get { return price; } }
}

public class Package : IItem
{
    string name;
    int price;
    List<IItem> items;

    public Package(string name) { this.name = name; items = new List<IItem>(); }
    public void AddItem(IItem item) => items.Add(item);
    public void RemoveItem(IItem item) => items.Remove(item);
    public string Name { get { return name; } }
    public int Price { 
        get
        {
            int total = 0;
            foreach (var item in items)
                total += item.Price;
            return total;
        } 
    }
}

public static class Tester
{
    public static void Test()
    {
        Package smallPackage = new Package("SmallPackage");
        smallPackage.AddItem(new Item("Pan", 20));
        smallPackage.AddItem(new Item("Mouse", 30));

        Package bigPackage = new Package("BigPackage");
        bigPackage.AddItem(smallPackage);
        bigPackage.AddItem(new Item("Lamp", 30));

        Console.WriteLine($"{bigPackage.Price}");
    }
}