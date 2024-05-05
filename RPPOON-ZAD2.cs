class Product
{
    public string Name { get; private set; } 
    public string Price { get; private set; } 
    public bool InStock { get; set; } 

    public Product(string name, string price)
    {
        this.Name = name;
        this.Price = price;
        this.InStock = false;
    }
}

class ProductManager
{
    List<Product> products; 

    public ProductManager(List<Product> inventory) 
    {
        products = inventory;
    }

    public void MakeProductAvailable(Product product)
    {
        foreach (Product prod in products)
        {
            if (product == prod)
                prod.InStock = true;
        }
    }
    public void RemoveUnavailable()
    { 
        products.RemoveAll(product => product.InStock == false);
    }
}

public class Note
{
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime Creation { get; private set; }

    public Note(string title, string text)
    {
        Title = title;
        Text = text;
        Creation = DateTime.Now;
    }
}

public class Notes
{
    public string Author { get; private set; }
    public List<Note> notes;

    public Notes(string author)
    {
        Author = author;
        notes = new List<Note>();
    }

    public void AddNote(Note note)
    {
        notes.Add(note);
    }
}

public class Location
{
    public DateTime CreationTime { get; private set; } 
    public double Latitude { get; private set; } 
    public double Longitude { get; private set; } 

    public Location(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}

public class PathManager
{
    private List<Location> locations; 

    public PathManager()
    {
        locations = new List<Location>();
    }

    public void AddLocation(Location location)
    {
        locations.Add(location);
    }

    public void RemoveLocation(Location location)
    {
        locations.Remove(location);
    }
}

class Average
{
    public double CalculateSum(double[] array)
    {
        double sum = 0;
        for (int i = 0; i < array.Length; i++) sum += array[i];
        return sum;
    }
    public List<double> CalculateAverage(List<double[]> arrays)
    {
        List<double> averages = new List<double>(); 
        foreach (double[] array in arrays)
        {
            averages.Add(CalculateSum(array) / array.Length);
        }
        return averages;
    }
}

class PalindromeFinder
{
    public static int CalculateOccurrence(char character, string text)
    {
        int occurrenceCount = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (character == text[i])
            {
                occurrenceCount++;
            }
        }
        return occurrenceCount;
    }

    public static List<char> ExtractUnique(string text)
    {
        List<char> uniqueCharacters = new List<char>();
        for (int i = 0; i < text.Length; i++)
        {
            if (CalculateOccurrence(text[i], text) == 1)
            {
                uniqueCharacters.Add(text[i]);
            }
        }
        return uniqueCharacters;
    }
}

class Palindrome
{
    public bool IsPalindrome(string text)
    {
        string cleanedText = text.Replace(" ", "").ToLower();
        string reversed = new string(cleanedText.Reverse().ToArray());
        return cleanedText.Equals(reversed);
    }
    public List<string> FindPalindromes(List<string> texts)
    {
        List<string> result = new List<string>();
        if (texts == null) return result;
        foreach (string text in texts)
        {
            if (IsPalindrome(text))
            {
                result.Add(text);
            }
        }
        return result;
    }
}